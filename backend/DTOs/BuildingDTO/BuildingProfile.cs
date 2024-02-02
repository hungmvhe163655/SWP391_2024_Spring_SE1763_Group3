using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.BuildingDTO
{
    public class BuildingProfile : Profile

    {
        public BuildingProfile()
        {
            CreateMap<CreateBuildingDTO, Building>()
            .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<CreateBuildingDTO, Building>()
            .ForMember(des => des.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<DeleteBuildingDTO, News>();
        }
    }
}
