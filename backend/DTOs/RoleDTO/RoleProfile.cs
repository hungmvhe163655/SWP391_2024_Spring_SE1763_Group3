using AutoMapper;
using Backend.DTOs.BillStatusDTO;
using Backend.Models;

namespace Backend.DTOs.RoleDTO

{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleDTO, Role>();
            CreateMap<UpdateRoleDTO, Role>();
            CreateMap<DeleteRoleDTO, Role>();
        }
    }
}