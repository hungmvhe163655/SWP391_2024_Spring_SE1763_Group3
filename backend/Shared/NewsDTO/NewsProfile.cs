using AutoMapper;
using Entities.Models;
using Shared.NewsDTO;

namespace Shared.BillStatusDTO
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<CreateNewsDTO, News>()
            .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateNewsDTO, News>()
            .ForMember(des => des.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<DeleteNewsDTO, News>();


        }
    }
}
