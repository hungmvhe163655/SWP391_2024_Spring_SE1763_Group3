using AutoMapper;
using Entities.Models;
using Shared.NewsDTO;
using Shared.TenantDTO;

namespace Shared.BillStatusDTO
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, ReadNewsDTO>().ReverseMap();
            CreateMap<CreateNewsDTO, News>();
            CreateMap<UpdateNewsDTO, News>().ReverseMap();


        }
    }
}
