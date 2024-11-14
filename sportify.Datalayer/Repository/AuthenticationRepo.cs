using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Repository
{
    public class AuthenticationRepo : Authentication
    {
        private SportifyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IToken _Token { get; set; }
         

        public AuthenticationRepo(SportifyContext context, IToken Token , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _Token = Token;
            _httpContextAccessor = httpContextAccessor;

        }


        public Task<RefreshToken> GenerateRefreshToken()
{
            var refreshtoken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                TokenExpires = DateTime.UtcNow.AddMinutes(60),
                TokenCreated = DateTime.Now
            };

            // Return the refresh token wrapped in a completed Task
            return Task.FromResult(refreshtoken);
        }



        private bool ValidateRefreshToken(string token)
        {
            
            return !string.IsNullOrEmpty(token); 
        }

        private void RefreshAccessToken(string refreshToken)
        {
            Console.WriteLine($"Access token refreshed using the refresh token: {refreshToken}");
        }


        public void SetRefreshToken(RefreshToken refreshToken , Users user)
        {
            if (refreshToken == null)
                throw new ArgumentNullException(nameof(refreshToken));

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, 
                Expires = refreshToken.TokenExpires, 
                SameSite = SameSiteMode.Strict 
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshtoken", refreshToken.Token, cookieOptions);

            user.RefreshToken = refreshToken.Token;
            user.TokenExpires = refreshToken.TokenExpires;
            user.TokenCreated = refreshToken.TokenCreated;
          

        }


        public async Task<LoginUserDto> LoginAsync(LoginDto loginDto)
        {
            var User = _context.users.Include(ur => ur.Roli).FirstOrDefault(u => u.Name == loginDto.Username);
            if (User == null)
            {
                throw new Exception("User not in Database");
            }

            var hmac = new HMACSHA512(User.PasswordSalt);


            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));


            for(var i = 0; i < passwordHash.Length; i++)
            {
                if(passwordHash[i] != User.PasswordHash[i])
                {
                    throw new Exception("Incorrect password");
                }
            }

     

            var refreshToken = await GenerateRefreshToken();  


            var loginUserDto = new LoginUserDto
            {
                Username = loginDto.Username,
                Token = _Token.CreateToken(User),
                Role = (User.Roleid == 1003) ? "Admin" : "User",
                




                Status = "ok"
            };

            SetrefreshToken(refreshToken, loginUserDto);






            return loginUserDto;

        }


        public void SetrefreshToken(RefreshToken refreshToken, LoginUserDto user)
        {
            if (refreshToken == null)
                throw new ArgumentNullException(nameof(refreshToken));

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = refreshToken.TokenExpires,
                SameSite = SameSiteMode.Strict
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshtoken", refreshToken.Token, cookieOptions);

            user.RefreshToken = refreshToken.Token;
            user.TokenExpires = refreshToken.TokenExpires;
            user.TokenCreated = refreshToken.TokenCreated;

        }

        public async Task<Users> RegisterAsync(RegisterDto register)
        {
            var User =  _context.users.FirstOrDefault(u => u.Name == register.Name);
            if (User != null)
            {
                throw new Exception("User is alredy Registerd");
            }

            var hmac = new HMACSHA512();

            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password));

            var Register = new Users
            {
                Name = register.Name,
                Surname = register.Surname,
                Adress = register.Adress,
                Email = register.Email,
                PasswordSalt = hmac.Key,
                PasswordHash = passwordHash,
                Roleid = 2

            };

            _context.users.Add(Register);

            await _context.SaveChangesAsync();

            return  Register;
        }

       
    }
}
