using sportify.core.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Interfaces
{
    public interface IToken
    {
        string CreateToken(Users user);

        string GetUserIdFromToken(string token);
    }
}
