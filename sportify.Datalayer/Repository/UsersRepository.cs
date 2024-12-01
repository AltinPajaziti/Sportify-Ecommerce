using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Repository
{
    public class UsersRepository : Iusers
    {

        private readonly SportifyContext _context;


        public UsersRepository(SportifyContext context)
        {
            _context = context;
            
        }
        public async Task<bool> DeleteUser(int id)
        {
            var users = await _context.users.Where(u => u.id == id ).FirstOrDefaultAsync();


            _context.users.Remove(users); 

            _context.SaveChanges();

            return true;


        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            var users = await _context.users.Where(u=> u.Roleid != 2).ToListAsync();

            return users;

        }



    }
}
