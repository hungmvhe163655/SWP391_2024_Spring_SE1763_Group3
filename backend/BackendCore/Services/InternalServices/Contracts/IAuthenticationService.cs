using Entities.Models;
using Shared.AuthenticationDTO;

namespace BackendCore.Services.InternalServices.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(LoginDTO user);
        Task<string> CreateToken();
    }
}
