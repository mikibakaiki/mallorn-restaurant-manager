using System.Security.Cryptography;
using System.Text;
using MallornRestaurantManagerApi.DTOs;
using MallornRestaurantManagerApi.Interfaces;
using MallornRestaurantManagerApi.Models;
using MallornRestaurantManagerApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MallornRestaurantManagerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly ITokenService _tokenService;
        public AccountController(UsersService usersService, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var userExists = await _usersService.FindByNameAsync(registerDto.Username);

            if (userExists)
            {
                return BadRequest("Username already in use");
            }

            using var hmac = new HMACSHA512();

            var user = new User()
            {
                UserName = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await _usersService.CreateAsync(user);

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _usersService.GetByNameAsync(loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");

            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            }; ;
        }

    }
}