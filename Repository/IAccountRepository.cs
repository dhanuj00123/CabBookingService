using API.Models;
using CabBookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignupAsync(User user);
        Task<string> LoginAsync(LoginModel LoginInModel);

    }
}
