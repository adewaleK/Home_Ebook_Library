using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyEbookLibrary.Data.Repositories.Database;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using MyEbookLibrary.Services;
using MyEbookLibrary.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthController(UserManager<User> userManager, DataContext context, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<authUserDto>> Login(LoginDto model)
        {

            //var user = await _authService.LoginAsync(model);
            if (!ModelState.IsValid) return Ok("Invalid details");

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        var userToReturn = new authUserDto
                        {
                            UserName = user.UserName,
                            Token = _jwtService.CreateToken(user)
                        };
                        return Ok(userToReturn);
                    }
                }
                return BadRequest("Wrong credentials");
            }

            return BadRequest("Wrong credentials");

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(registerDto model)
        {
            if (!ModelState.IsValid) return Ok("Invalid details");

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);

            if (user != null)
                return Ok("Email already exist");

            var newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FullName,
                Email = model.EmailAddress,
                UserName = model.EmailAddress
            };

            
            var newUserResponse = await _userManager.CreateAsync(newUser, model.Password);

            if (newUserResponse.Succeeded)
            {

                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                return Ok("user successfully registered");
            }
            else
            {
                return BadRequest("registration failed");
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> LogOut()
        {
           await _signInManager.SignOutAsync();
           return Ok("Successfully logged out");
        }
    }
}
