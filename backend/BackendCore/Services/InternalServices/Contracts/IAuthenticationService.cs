using Entities.Models;

namespace BackendCore.Services.InternalServices.Contracts
{
    public interface IAuthenticationService
    {
        Task<string> CreateToken();
    }
}
