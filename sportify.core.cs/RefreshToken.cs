using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class RefreshToken
    {

        public string Token { get; set; }
        public DateTime TokenCreated { get; set; }

        public DateTime TokenExpires { get; set; }
    }
}
