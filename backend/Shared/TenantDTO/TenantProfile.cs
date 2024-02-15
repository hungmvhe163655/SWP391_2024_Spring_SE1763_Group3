using AutoMapper;
using Entities.Models;

namespace Shared.TenantDTO
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenant, ReadTenantDTO>().ReverseMap();
            CreateMap<CreateTenantDTO, Tenant>();
            CreateMap<UpdateTenantDTO, Tenant>().ReverseMap();
        }
    }
}
