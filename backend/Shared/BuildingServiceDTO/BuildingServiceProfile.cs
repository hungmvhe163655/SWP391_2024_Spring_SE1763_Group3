using AutoMapper;
using Shared.BillStatusDTO;
using Entities.Models;

namespace Shared.BuildingServiceDTO
{
    public class BuildingServiceProfile : Profile
    {
        public BuildingServiceProfile() {
            CreateMap<UpdateBuildingServiceDTO, BuildingService>();
            CreateMap<CreateBuildingServiceDTO, BuildingService>();
        }
    }
}
