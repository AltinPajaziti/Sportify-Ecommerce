using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class Users : BaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Adress { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int Roleid { get; set; }

        public Roles Roli { get; set; }

        public string Email { get; set; }

        public Basket Basket { get; set; }


        public ICollection<FavoriteProducts> FavoriteProducts { get; set; }

    }
}
