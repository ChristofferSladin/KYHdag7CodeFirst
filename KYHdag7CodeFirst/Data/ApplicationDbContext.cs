using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHdag7CodeFirst.Data
{
    public class ApplicationDbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Person> Invoice { get; set; }
        
        public ApplicationDbContext()
        {

        }
    }
}
