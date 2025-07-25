using ItemManagementSystem.Domain.DataModels;
using ItemManagementSystem.Domain.Dto;
using AutoMapper;
using ItemManagementSystem.Domain.Dto.Request;

namespace ItemManagementSystem.Application.MappingProfiles;

public class ItemManagementProfile : Profile
{
    public ItemManagementProfile()
    {
      CreateMap<ItemType, ItemTypeDto>().ReverseMap();
      CreateMap<ItemType, ItemTypeCreateRequest>().ReverseMap();
      CreateMap<ItemType, ItemTypeResponseDto>();
      CreateMap<ItemType, ItemTypePagedDto>();
      CreateMap<ItemModel, ItemModelDto>()
          .ForMember(dest => dest.ItemTypeName, opt => opt.MapFrom(src => src.ItemType.Name))
          .ReverseMap();
      CreateMap<ItemModel, ItemModelResponseDto>()
          .ForMember(dest => dest.ItemTypeName, opt => opt.MapFrom(src => src.ItemType.Name));
      CreateMap<ItemModel, ItemModelCreateDto>().ReverseMap();
      CreateMap<PurchaseRequest, PurchaseRequestDto>().ReverseMap();
      CreateMap<PurchaseRequest, PurchaseRequestCreateDto>().ReverseMap();
      CreateMap<PurchaseRequestDetail, PurchaseRequestDetailDto>().ReverseMap();
      CreateMap<ItemRequest, ItemRequestDto>()
      .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ItemRequestDetails));

      CreateMap<CreateItemRequestWithStatusDto, ItemRequest>()
          .ForMember(dest => dest.Id, opt => opt.Ignore())
          .ForMember(dest => dest.RequestNumber, opt => opt.Ignore())
          .ForMember(dest => dest.StatusId, opt => opt.Ignore())
          .ForMember(dest => dest.Status, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
          .ForMember(dest => dest.ItemRequestDetails, opt => opt.Ignore());

      CreateMap<CreateItemRequestDetailDto, ItemRequestDetail>()
          .ForMember(dest => dest.Id, opt => opt.Ignore())
          .ForMember(dest => dest.ItemRequestId, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

    CreateMap<PurchaseRequestDetailCreateDto, PurchaseRequestDetail>()
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
    .ForMember(dest => dest.PurchaseRequestId, opt => opt.Ignore())
    .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

    CreateMap<ItemRequestDetailDto, ItemRequestDetail>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.ItemRequestId, opt => opt.Ignore())
           .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
           .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

    CreateMap<ItemRequest, ItemRequestDto>()
           .ForMember(dest => dest.Items, opt => opt.Ignore());

    CreateMap<ItemRequestDetail, ItemRequestDetailsDto>()
      .ForMember(dest => dest.ItemModelName, opt => opt.MapFrom(src => src.ItemModel.Name))
      .ForMember(dest => dest.ItemModelDescription, opt => opt.MapFrom(src => src.ItemModel.Description))
      .ForMember(dest => dest.ItemTypeId, opt => opt.MapFrom(src => src.ItemModel.ItemTypeId))
      .ForMember(dest => dest.ItemTypeName, opt => opt.MapFrom(src => src.ItemModel.ItemType.Name));
    CreateMap<ItemRequest, ItemRequestDto>()
        .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ItemRequestDetails));

    CreateMap<ReturnRequest, ReturnRequestDto>().ReverseMap();
    CreateMap<ReturnRequestDetail, ReturnRequestDetailDto>().ReverseMap();

    CreateMap<CreateItemRequestDetailDto, ItemRequestDetail>()
        .ForMember(dest => dest.Id, opt => opt.Ignore())
        .ForMember(dest => dest.ItemRequestId, opt => opt.Ignore())
        .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
  }
}
