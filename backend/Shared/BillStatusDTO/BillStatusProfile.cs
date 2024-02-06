using AutoMapper;
using Entities.Models;

namespace Shared.BillStatusDTO
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
