using AutoMapper;
using Entities.Models;

namespace Shared.RequestTypeDTO
{
    public class RequestTypeProfile : Profile
    {
        public RequestTypeProfile()
        {
            CreateMap<RequestType, ReadRequestTypeDTO>().ReverseMap();
            CreateMap<CreateRequestTypeDTO, RequestType>();
            CreateMap<UpdateRequestTypeDTO, RequestType>().ReverseMap();
        }
    }
}

