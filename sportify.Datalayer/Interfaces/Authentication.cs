using sportify.core.cs;
using sportify.Datalayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Interfaces
{
    public interface Authentication
    {

        public Task<LoginUserDto> LoginAsync(LoginDto loginDto);
        public Task<Users> RegisterAsync( RegisterDto register);


    }
}
