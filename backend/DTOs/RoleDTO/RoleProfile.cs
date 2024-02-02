using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.RoleDTO
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleDTO, Role>();
        }
    }
}
