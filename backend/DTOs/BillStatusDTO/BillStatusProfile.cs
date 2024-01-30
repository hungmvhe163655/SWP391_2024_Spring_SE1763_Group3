using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.BillStatusDTO
{
    public class BillStatusProfile : Profile
    {
        public BillStatusProfile()
        {
            CreateMap<UpdateBillStatusDTO, BillStatus>();
            CreateMap<CreateBillStatusDTO, BillStatus>();
        }
    }
}
