using AutoMapper;
using Entities.Models;

namespace Shared.RequestStatusDTO
{
    public class RequestStautsProfile : Profile
    {
        public RequestStautsProfile()
        {
            CreateMap<UpdateRequestStatusDTO, RequestStatus>();
            CreateMap<CreateRequestStatusDTO, RequestStatus>();
        }

    }
}
