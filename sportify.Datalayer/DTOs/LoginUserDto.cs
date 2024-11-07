using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.DTOs
{
    public class LoginUserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public string Status { get; set; } = string.Empty;
        public string Role { get; set; }
    }
}
