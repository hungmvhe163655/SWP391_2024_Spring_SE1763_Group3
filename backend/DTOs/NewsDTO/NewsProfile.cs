using AutoMapper;
using Backend.DTOs.NewsDTO;
using Backend.DTOs.RequestDTO;
using Backend.Models;

namespace Backend.DTOs.BillStatusDTO
{
    public class NewsProfile : Profile
    {
        public  NewsProfile()
        {
            CreateMap<CreateNewsDTO, News>()
            .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateNewsDTO, News>()
            .ForMember(des => des.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<DeleteNewsDTO, News>();
            
            
        }
    }
}
