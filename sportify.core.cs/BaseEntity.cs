using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string? Insertedby { get; set; }

        public DateTime? LastModified { get; set; }



    }
}
