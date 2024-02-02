using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.BillDTO
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<CreateBillDTO, Bill>();
        }
    }
}
