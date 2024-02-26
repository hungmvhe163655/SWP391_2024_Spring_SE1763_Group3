using AutoMapper;
using Entities.Models;
using Shared.TenantDTO;

namespace Shared.RequestStatusDTO
{
    public class RequestStautsProfile : Profile
    {
        public RequestStautsProfile()
        {
            CreateMap<RequestStatus, ReadRequestStatusDTO>().ReverseMap();
            CreateMap<UpdateRequestStatusDTO, RequestStatus>().ReverseMap(); ;
            CreateMap<CreateRequestStatusDTO, RequestStatus>().ReverseMap(); ;
        }

    }
}
