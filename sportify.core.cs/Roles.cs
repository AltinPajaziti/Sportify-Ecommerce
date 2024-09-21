using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class Roles 
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
        public ICollection<Users> User { get; set; }

    }
}
