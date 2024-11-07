using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.DataLayer.cs
{
    public class SportifyContext : DbContext
    {
        public SportifyContext( DbContextOptions<SportifyContext> options) : base(options)
        {
            
        }
    }
}
