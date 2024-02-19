using AutoMapper;
using Entities.Models;

namespace Shared.RoleDTO
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, ReadRoleDTO>().ReverseMap();
            CreateMap<CreateRoleDTO, Role>();
            CreateMap<UpdateRoleDTO, Role>().ReverseMap();
        }
    }
}
