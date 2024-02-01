using AutoMapper;
using Backend.DTOs.BillStatusDTO;
using Backend.Models;

namespace Backend.DTOs.BuildingServiceDTO
{
    public class BuildingServiceProfile : Profile
    {
        public BuildingServiceProfile() {
            CreateMap<UpdateBuildingServiceDTO, BuildingService>();
            CreateMap<CreateBuildingServiceDTO, BuildingService>();
        }
    }
}
