using System.Linq.Expressions;
using AutoMapper;
using ItemManagementSystem.Application.Interface;
using ItemManagementSystem.Domain.Constants;
using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto;
using ItemManagementSystem.Domain.Dto.Request;
using ItemManagementSystem.Domain.Exception;
using ItemManagementSystem.Infrastructure.Interface;

namespace ItemManagementSystem.Application.Implementation
{
    public class ItemModelService : IItemModelService
    {
        private readonly IRepository<ItemModel> _itemModaRepo;
        private readonly IRepository<ItemType> _itemTypeRepo;
        private readonly IRepository<ItemRequestDetail> _ItemRequestDetailRepo;
        private readonly IRepository<ItemRequest> _itemRequestRepo;
        private readonly IMapper _mapper;

        public ItemModelService(IRepository<ItemModel> repo, IMapper mapper,
            IRepository<ItemRequestDetail> ItemRequestDetailRepo, IRepository<ItemRequest> itemRequestRepo, IRepository<ItemType> itemtyperepo)
        {
            _ItemRequestDetailRepo = ItemRequestDetailRepo;
            _itemModaRepo = repo;
            _mapper = mapper;
            _itemRequestRepo = itemRequestRepo;
            _itemTypeRepo = itemtyperepo;
        }

        public async Task<ItemModelDto> CreateAsync(ItemModelDto dto)
        {
            dto.Id = 0;
            dto.modifiedBy = null;
            //if ItemModal with same name already exists in same ItemType, throw exception
            var exists = (await _itemModaRepo.FindAsync(
                it => it.Name.ToLower() == dto.Name.ToLower() && it.ItemTypeId == dto.ItemTypeId
            )).Any();
            if (exists)
                throw new AlreadyExistsException(AppMessages.ItemModelAlreadyExists);

            var entity = _mapper.Map<ItemModel>(dto);
            entity.Quantity = 0;
            var created = await _itemModaRepo.AddAsync(entity);
            return _mapper.Map<ItemModelDto>(created);
        }

        public async Task<ItemModelCreateDto> CreateAsync(ItemModelCreateDto dto, int userId)
        {
            dto.Name = dto.Name.Trim();

            var exists = (await _itemModaRepo.FindAsync(
                it => it.Name.ToLower() == dto.Name.ToLower() && it.ItemTypeId == dto.ItemTypeId
            )).Any();
            if (exists)
                throw new AlreadyExistsException(AppMessages.ItemModelAlreadyExists);

            var itemTypeCheck = await _itemTypeRepo.GetByIdAsync(dto.ItemTypeId);
            if (itemTypeCheck == null || itemTypeCheck.IsDeleted)
                throw new NullObjectException(AppMessages.ItemTypeNotFound);

            var entity = _mapper.Map<ItemModel>(dto);
            entity.CreatedBy = userId;
            entity.Quantity = 0;

            var created = await _itemModaRepo.AddAsync(entity);
            return _mapper.Map<ItemModelCreateDto>(created);
        }

        public async Task<ItemModelResponseDto?> GetByIdAsync(int id)
        {
            var entities = await _itemModaRepo.FindIncludingAsync(e => e.Id == id && e.IsDeleted == false, e => e.ItemType);
            var entity = entities.FirstOrDefault();
            if (entity == null)
                throw new NullObjectException(AppMessages.ItemModelNotFound);
            return _mapper.Map<ItemModelResponseDto>(entity);
        }

        public async Task<IEnumerable<ItemModelDto>> GetAllAsync()
        {
            var entities = await _itemModaRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemModelDto>>(entities);
        }


        public async Task<PagedResultDto<ItemModelResponseDto>> GetPagedAsync(ItemModelFilterDto filter)
        {
            Expression<Func<ItemModel, bool>> filterExpression = e =>
                (string.IsNullOrEmpty(filter.SearchTerm) || e.Name.ToLower().Trim().Contains(filter.SearchTerm.ToLower().Trim())) &&
                (!filter.ItemTypeId.HasValue || e.ItemTypeId == filter.ItemTypeId.Value) &&
                !e.IsDeleted;

            Func<IQueryable<ItemModel>, IOrderedQueryable<ItemModel>> orderBy = query =>
            {
                if (!string.IsNullOrEmpty(filter.SortBy))
                {
                    if (filter.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                        return filter.SortDirection == "desc" ? query.OrderByDescending(e => e.Name) : query.OrderBy(e => e.Name);
                    if (filter.SortBy.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase))
                        return filter.SortDirection == "desc" ? query.OrderByDescending(e => e.CreatedAt) : query.OrderBy(e => e.CreatedAt);
                    if (filter.SortBy.Equals("Quantity", StringComparison.OrdinalIgnoreCase))
                        return filter.SortDirection == "desc" ? query.OrderByDescending(e => e.Quantity) : query.OrderBy(e => e.Quantity);
                }
                return query.OrderBy(e => e.Name);
            };

            var pagedResult = await _itemModaRepo.GetPagedAsyncWithIncludes(
                filterExpression,
                orderBy,
                filter.Page,
                filter.PageSize,
                e => e.ItemType);

            return new PagedResultDto<ItemModelResponseDto>
            {
                Items = _mapper.Map<List<ItemModelResponseDto>>(pagedResult.Items),
                TotalCount = pagedResult.TotalCount,
                Page = pagedResult.Page,
                PageSize = pagedResult.PageSize
            };
        }

        public async Task<ItemModelDto> UpdateAsync(int id, ItemModelDto dto)
        {
            dto.Id = id;
            var entity = await _itemModaRepo.GetByIdAsync(id);
            if (entity == null)
                throw new NullObjectException(AppMessages.ItemModelNotFound);

            // if ItemModel with same name already exists in same ItemType, throw exception
            var exists = (await _itemModaRepo.FindAsync(
                it => it.Name.ToLower() == dto.Name.ToLower() && it.ItemTypeId == dto.ItemTypeId && it.Id != id
            )).Any();
            if (exists)
                throw new AlreadyExistsException(AppMessages.ItemModelAlreadyExists);

            dto.createdBy = entity.CreatedBy;

            // Do not allow updating quantity from here
            var existingQuantity = entity.Quantity;
            _mapper.Map(dto, entity);
            entity.Quantity = existingQuantity;

            await _itemModaRepo.UpdateAsync(entity);
            return _mapper.Map<ItemModelDto>(entity);
        }

        public async Task<ItemModelCreateDto> UpdateAsync(int id, ItemModelCreateDto dto, int userId)
        {
            var entity = await _itemModaRepo.GetByIdAsync(id);
            if (entity == null)
                throw new NullObjectException(AppMessages.ItemModelNotFound);

            dto.Name = dto.Name.Trim();  

            var exists = (await _itemModaRepo.FindAsync(
                it => it.Name.ToLower() == dto.Name.ToLower() && it.ItemTypeId == dto.ItemTypeId && it.Id != id
            )).Any();
            if (exists)
                throw new AlreadyExistsException(AppMessages.ItemModelAlreadyExists);

            bool isItemTypeIdExist = (await _itemModaRepo.FindAsync(
                it => it.ItemTypeId == dto.ItemTypeId
            )).Any();
            if (!isItemTypeIdExist)
                throw new NullObjectException(AppMessages.ItemTypeNotFound);


            var existingQuantity = entity.Quantity;
            _mapper.Map(dto, entity);
            entity.Quantity = existingQuantity;
            entity.ModifiedBy = userId;
            entity.UpdatedAt = DateTime.UtcNow;

            await _itemModaRepo.UpdateAsync(entity);
            return _mapper.Map<ItemModelCreateDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _itemModaRepo.GetByIdAsync(id);
            if (entity == null)
                throw new NullObjectException(AppMessages.ItemModelNotFound);

            if (entity.IsDeleted)
                throw new CustomException("Item model is already deleted.");

            var ItemRequestDetails = await _ItemRequestDetailRepo.FindAsync(ri => ri.ItemModelId == id && !ri.IsDeleted);

            //  check if any of their ItemRequest.StatusId == Pending
            foreach (var ItemRequestDetail in ItemRequestDetails)
            {
                var itemRequest = await _itemRequestRepo.GetByIdAsync(ItemRequestDetail.ItemRequestId);
                if (itemRequest != null && itemRequest.StatusId == (int)StatusEnum.Pending)
                {
                    throw new CustomException(AppMessages.ItemModelHasAssociatedRequests);
                }
            }

            await _itemModaRepo.DeleteAsync(entity);
        }
    }
}