using AutoMapper;

namespace Backend.DTOs.BillStatusDTO
{
    public class BillStatusProfile : Profile
    {
        public BillStatusProfile() 
        {
            CreateMap<UpdateBillStatusDTO, BillStatus>();
        }
    }
}
