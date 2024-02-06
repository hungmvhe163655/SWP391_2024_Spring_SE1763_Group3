using AutoMapper;
using Shared.NewsDTO;
using Shared.RequestDTO;
using Entities.Models;

namespace Shared.BillStatusDTO
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
