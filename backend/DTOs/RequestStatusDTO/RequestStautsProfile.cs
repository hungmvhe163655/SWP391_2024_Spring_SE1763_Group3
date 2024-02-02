using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.RequestStatusDTO
{
    public class RequestStautsProfile : Profile
    {
        public RequestStautsProfile() {
            CreateMap<UpdateRequestStatusDTO, RequestStatus>();
            CreateMap<CreateRequestStatusDTO, RequestStatus>();
        }
        
    }
}
