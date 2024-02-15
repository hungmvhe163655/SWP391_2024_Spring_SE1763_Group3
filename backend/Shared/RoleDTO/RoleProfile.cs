using AutoMapper;
using Entities.Models;

namespace Shared.RoleDTO
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleDTO, Role>();
        }
    }
}
