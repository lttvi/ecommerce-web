using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Logout successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM userInput)
        {
            var result = await _signInManager.PasswordSignInAsync(userInput.Username, userInput.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Login successfully");
            }
            else
            {
                return NotFound("No account matches");
            }
        }

        public class LoginVM
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
