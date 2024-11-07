using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }


        public byte[] PasswordHAsh { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Token { get; set; }



    }
}
