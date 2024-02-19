using AutoMapper;
using Entities.Models;
using Shared.TenantDTO;

namespace Shared.BuildingServiceDTO
{
    public class BuildingServiceProfile : Profile
    {
        public BuildingServiceProfile()
        {
            CreateMap<BuildingService, ReadBuildingServiceDTO>().ReverseMap();
            CreateMap<CreateBuildingServiceDTO, BuildingService>();
            CreateMap<UpdateBuildingServiceDTO, BuildingService>().ReverseMap();
        }
    }
}
