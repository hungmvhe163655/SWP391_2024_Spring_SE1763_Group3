using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.RequestDTO
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<CreateRequestDTO, Request>()
                .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
