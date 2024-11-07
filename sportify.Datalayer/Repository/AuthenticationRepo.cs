using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Repository
{
    public class AuthenticationRepo : Authentication
    {
        private SportifyContext _context;
        public IToken _Token { get; set; }
         

        public AuthenticationRepo(SportifyContext context, IToken Token)
        {
            _context = context;
            _Token = Token;
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


            var loginUserDto = new LoginUserDto
            {
                Username = loginDto.Username,
                Token = _Token.CreateToken(User),
                Role = (User.Roleid == 1003) ? "Admin" : "User",

                Status = "ok"
            };

            return loginUserDto;

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
