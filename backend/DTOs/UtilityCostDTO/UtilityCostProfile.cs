using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.UtilityCostDTO
{
    public class UtilityCostProfile : Profile
    {
        public UtilityCostProfile()
        {
            CreateMap<CreateUtilityCostDTO, UtilityCost>();
            CreateMap<UpdateUtilityCostDTO, UtilityCost>();
        }
    }
}
