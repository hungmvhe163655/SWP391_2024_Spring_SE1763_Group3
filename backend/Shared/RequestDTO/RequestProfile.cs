using AutoMapper;
using Entities.Models;

namespace Shared.RequestDTO
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<CreateRequestDTO, Request>();
            CreateMap<Request, ReadRequestDTO>()
                .ForMember(dest => dest.TenantName, opt => opt.MapFrom(src => src.Tenant.FullName))
                .ForMember(dest => dest.HomeManagerName, opt => opt.MapFrom(src => src.HomeManager.FullName))
                .ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType.Type))
                .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src => src.RequestStatus.Status));
        }
    }
}
