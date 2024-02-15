using AutoMapper;
using Entities.Models;

namespace Shared.BillDTO
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<CreateBillDTO, Bill>();
        }
    }
}
