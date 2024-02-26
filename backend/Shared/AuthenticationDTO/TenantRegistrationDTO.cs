using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AuthenticationDTO
{
    public record TenantRegistrationDTO : RegistrationBaseDTO
    {
        public DateTime Dob { get; set; }

        [MaxLength(500)]
        public string Address { get; set; } = null!;
    }
}
