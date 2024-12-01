using sportify.core.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Interfaces
{
    public interface Iusers
    {
        Task<IEnumerable<Users>> GetAllUsers();

        Task<bool> DeleteUser(int id);





    }
}
