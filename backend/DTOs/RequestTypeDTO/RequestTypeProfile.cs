using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.RequestTypeDTO
{
    public class RequestTypeProfile : Profile
    {
        public RequestTypeProfile()
        {
            CreateMap<UpdateRequestTypeDTO, RequestType>();
            CreateMap<CreateRequestTypeDTO, RequestType>();
        }
    }
}
