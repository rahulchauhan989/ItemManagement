using System.Security.Cryptography;
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
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly IRepository<PurchaseRequest> _purchaseRepo;
        private readonly IRepository<ItemModel> _itemModelRepo;
        private readonly IRepository<ItemType> _itemTypeRepo;
        private readonly IRepository<PurchaseRequestDetail> _purchaseItemRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;

        public PurchaseRequestService(
            IRepository<PurchaseRequest> purchaseRepo,
            IRepository<ItemModel> itemModelRepo,
            IRepository<PurchaseRequestDetail> purchaseItemRepo,
            IRepository<ItemType> itemTypeRepo,
            IRepository<User> userRepo,
            IMapper mapper)
        {
            _purchaseRepo = purchaseRepo;
            _itemModelRepo = itemModelRepo;
            _purchaseItemRepo = purchaseItemRepo;
            _itemTypeRepo = itemTypeRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<PurchaseRequestDto> CreateAsync(PurchaseRequestDto dto)
        {
            dto.Id = 0;
            dto.InvoiceNumber = GenerateInvoiceNumber().ToString();
            dto.UpdatedAt = null;
            dto.ModifiedBy = null;

            if (dto.CreatedBy == null)
            {
                throw new NullObjectException(AppMessages.NullCreatedBy);
            }

            // var itemType = await _itemTypeRepository.GetByIdAsync(dto.ItemTypeId);
            // if (itemType == null)
            //     throw new CustomException($"ItemType with Id {dto.ItemTypeId} does not exist.");

            var purchaseEntity = _mapper.Map<PurchaseRequest>(dto);
            var createdPurchase = await _purchaseRepo.AddAsync(purchaseEntity);

            var savedItems = new List<PurchaseRequestDetailDto>();
            foreach (var itemDto in dto.Items)
            {
                var itemModel = await _itemModelRepo.GetByIdAsync(itemDto.ItemModelId);
                if (itemModel == null || itemModel.IsDeleted)
                    throw new NullObjectException($"ItemModel with id {itemDto.ItemModelId} not found.");

                itemModel.Quantity += itemDto.Quantity;
                await _itemModelRepo.UpdateAsync(itemModel);

                var purchaseItem = new PurchaseRequestDetail
                {
                    PurchaseRequestId = createdPurchase.Id,
                    ItemModelId = itemDto.ItemModelId,
                    Quantity = itemDto.Quantity,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = (int)dto.CreatedBy,
                    IsDeleted = false
                };
                await _purchaseItemRepo.AddAsync(purchaseItem);

                savedItems.Add(new PurchaseRequestDetailDto
                {
                    ItemModelId = itemDto.ItemModelId,
                    Quantity = itemDto.Quantity
                });
            }

            var resultDto = _mapper.Map<PurchaseRequestDto>(createdPurchase);
            resultDto.Items = savedItems;
            return resultDto;
        }

        public async Task<PurchaseRequestDto> CreateAsync(PurchaseRequestCreateDto dto, int userId)
        {
            if (dto.Items == null || dto.Items.Count == 0)
                throw new NullObjectException(AppMessages.PurchaseRequestDetailsCannotBeEmpty);

            // Check for duplicate ItemModelId in the items list
            var duplicateItemModelIds = dto.Items
                .GroupBy(i => i.ItemModelId)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateItemModelIds.Any())
                throw new CustomException(AppMessages.duplicateItemModelIds);

            foreach (var itemdto in dto.Items)
            {
                var itemModel = await _itemModelRepo.GetByIdAsync(itemdto.ItemModelId);
                if (itemModel == null || itemModel.IsDeleted)
                    throw new NullObjectException(AppMessages.ItemModelsNotFound);
            }

            var purchaseEntity = _mapper.Map<PurchaseRequest>(dto);
            purchaseEntity.Date = DateTime.UtcNow;
            var invoiceNumberTask = GenerateInvoiceNumber();
            purchaseEntity.InvoiceNumber = invoiceNumberTask.GetAwaiter().GetResult();
            purchaseEntity.CreatedBy = userId;
            var createdPurchase = await _purchaseRepo.AddAsync(purchaseEntity);

            var savedItems = new List<PurchaseRequestDetailDto>();
            foreach (var itemDto in dto.Items)
            {
                var itemModel = await _itemModelRepo.GetByIdAsync(itemDto.ItemModelId);
                if (itemModel == null || itemModel.IsDeleted)
                    throw new NullObjectException(AppMessages.ItemModelsNotFound);

                itemModel.Quantity += itemDto.Quantity;
                await _itemModelRepo.UpdateAsync(itemModel);

                // AutoMapper for mapping
                var purchaseItem = _mapper.Map<PurchaseRequestDetail>(itemDto);
                purchaseItem.PurchaseRequestId = createdPurchase.Id;
                purchaseItem.CreatedBy = userId;
                purchaseItem.IsDeleted = false;

                await _purchaseItemRepo.AddAsync(purchaseItem);

                var purchaseItemDto = _mapper.Map<PurchaseRequestDetailDto>(purchaseItem);
                savedItems.Add(purchaseItemDto);
            }

            var resultDto = _mapper.Map<PurchaseRequestDto>(createdPurchase);
            resultDto.Items = savedItems;
            return resultDto;
        }

        public async Task<PurchaseRequestResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _purchaseRepo.GetByIdAsync(id);
            if (entity == null)
                throw new NullObjectException(AppMessages.PurchaseRequestNotFound);

            var user = await _userRepo.GetByIdAsync(entity.CreatedBy);
            string? createdByUserName = user?.Name;

            var dto = new PurchaseRequestResponseDto
            {
                Id = entity.Id,
                Date = entity.Date,
                InvoiceNumber = entity.InvoiceNumber,
                CreatedBy = createdByUserName,
                Items = new List<PurchaseRequestDetailResponseDto>()
            };

            var items = await _purchaseItemRepo.FindAsync(x => x.PurchaseRequestId == entity.Id);

            foreach (var item in items)
            {
                var itemModel = await _itemModelRepo.GetByIdAsync(item.ItemModelId);
                string? itemModelName = itemModel?.Name;
                string? itemTypeName = null;

                if (itemModel != null)
                {
                    var itemType = await _itemTypeRepo.GetByIdAsync(itemModel.ItemTypeId);
                    itemTypeName = itemType?.Name;
                }

                dto.Items.Add(new PurchaseRequestDetailResponseDto
                {
                    Name = itemModelName,
                    Quantity = item.Quantity,
                    ItemType = itemTypeName
                });
            }

            return dto;
        }

        public async Task<IEnumerable<PurchaseRequestResponseDto>> GetAllAsync(PurchaseRequestFilterDto filter)
        {
            var filterProperties = new Dictionary<string, string?>();

            var pagedResult = await _purchaseRepo.GetPagedWithMultipleFiltersAndSortAsync(
                filterProperties,
                filter.SortBy,
                filter.SortDirection,
                filter.Page,
                filter.PageSize);

            var result = new List<PurchaseRequestResponseDto>();
            foreach (var entity in pagedResult.Items)
            {
                var user = await _userRepo.GetByIdAsync(entity.CreatedBy);
                string? createdByUserName = user?.Name;

                var dto = new PurchaseRequestResponseDto
                {
                    Id = entity.Id,
                    Date = entity.Date,
                    InvoiceNumber = entity.InvoiceNumber,
                    CreatedBy = createdByUserName,
                    Items = new List<PurchaseRequestDetailResponseDto>()
                };

                var items = await _purchaseItemRepo.FindAsync(x => x.PurchaseRequestId == entity.Id);

                foreach (var item in items)
                {
                    var itemModel = await _itemModelRepo.GetByIdAsync(item.ItemModelId);
                    string? itemModelName = itemModel?.Name;
                    string? itemTypeName = null;

                    if (itemModel != null)
                    {
                        var itemType = await _itemTypeRepo.GetByIdAsync(itemModel.ItemTypeId);
                        itemTypeName = itemType?.Name;
                    }

                    dto.Items.Add(new PurchaseRequestDetailResponseDto
                    {
                        Name = itemModelName,
                        Quantity = item.Quantity,
                        ItemType = itemTypeName
                    });
                }
                result.Add(dto);
            }
            return result;
        }

        private async Task<string> GenerateInvoiceNumber()
        {
            var today = DateTime.UtcNow.Date;
            var countToday = await _purchaseRepo.GetAllAsync();
            var todaysCount = countToday.Count(pr => pr.Date.Date == today);
            var sequenceNumber = todaysCount + 1;
            var sequenceStr = sequenceNumber.ToString().PadLeft(3, '0');
            return $"PR{today:yyyyMMdd}{sequenceStr}";
        }
    }
}