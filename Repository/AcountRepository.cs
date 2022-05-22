using API.Authentication;
using API.Models;
using CabBookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository
{
    public class AcountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AcountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        public async Task<IdentityResult> SignupAsync(User user)
        {
            //var userExists = await _userManager.FindByNameAsync(user.UserName);
            //if (userExists != null)
            //{
            //    return  IdentityResult.Failed();
            //}

                var use = new ApplicationUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
            };
            return await _userManager.CreateAsync(use, user.Password);
        }

      //  public async Task<IActionResult> LoginAsync()

        public async Task<string> LoginAsync([FromBody]LoginModel loginInModel)
        {
            var result = await _userManager.FindByNameAsync(loginInModel.username);/*, loginInModel.Password, false, false);*/

            if (result != null && await _userManager.CheckPasswordAsync(result, loginInModel.Password))
            {
                
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginInModel.username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                
                var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
            //var authClaims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, loginInModel.Email),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};
            //var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            //var token = new JwtSecurityToken(
            //    issuer: _configuration["JWT:ValidIssuer"],
            //    audience: _configuration["JWT:ValidAudience"],
            //    expires: DateTime.Now.AddDays(1),
            //    claims: authClaims,
            //    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
            //    );

            //return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
