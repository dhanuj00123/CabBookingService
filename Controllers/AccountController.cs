using API.Models;
using API.Repository;
using CabBookingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository )
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody]User user)
        {
            var result = await _accountRepository.SignupAsync(user);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            
            return BadRequest(result.Errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _accountRepository.LoginAsync(loginModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized("Invalid Credentials");
            }
            return Ok(result);
        }
    }
}
