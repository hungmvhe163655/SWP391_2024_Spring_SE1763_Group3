using AutoMapper;
using Entities.Models;

namespace Shared.BuildingDTO
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<CreateBuildingDTO, Building>();
        }
    }
}
