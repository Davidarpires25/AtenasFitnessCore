using AtenasCore.Server.Data;
using AtenasCore.Server.Dtos;
using AtenasCore.Server.Dtos.Account;
using AtenasCore.Server.interfaces;
using AtenasCore.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtenasCore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _TokenService;
        private readonly SignInManager<AppUser> _SignInManager;

        public AccountController(UserManager<AppUser> userManager,ITokenService tokenService, SignInManager<AppUser> signInManager){
            _userManager=userManager;
            _TokenService=tokenService;
            _SignInManager=signInManager;

        }


        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginUserDto loginUserDto){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest,ModelState);
            }
            var user= await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==loginUserDto.UserName);
            if(user==null){
                return StatusCode(StatusCodes.Status401Unauthorized,"Invalid username!");
            }
            var result = await _SignInManager.CheckPasswordSignInAsync(user,loginUserDto.Password,false);
            if(!result.Succeeded){
                return StatusCode(StatusCodes.Status401Unauthorized,"Username or password Incorrect");
            }
            var login=new CreateUserDto{
                UserName=user.UserName,
                Email=user.Email,
                Token= _TokenService.createToken(user)                
                
            };
            return StatusCode(StatusCodes.Status200OK,"Login Succes");

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUsertDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == registerDto.UserName.ToLower()))
                return BadRequest("Username is already taken");

            if (await _userManager.Users.AnyAsync(x => x.Email.ToLower() == registerDto.Email.ToLower()))
                return BadRequest("Email is already taken");

            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName= registerDto.FirstName,
                LastName=registerDto.LastName,
                Dni=registerDto.Dni,
                Age=registerDto.Age
                
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(
                        new CreateUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = _TokenService.createToken(appUser)
                        }
                    );
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
            
        }
       

        
    }



}