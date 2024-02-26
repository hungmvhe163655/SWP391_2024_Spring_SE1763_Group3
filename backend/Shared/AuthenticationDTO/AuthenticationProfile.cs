using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AuthenticationDTO
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile() {
            CreateMap<TenantRegistrationDTO, Tenant>();
        }
    }
}
