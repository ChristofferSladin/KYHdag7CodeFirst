using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHdag7CodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Person> Invoice { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        {
            // tom constructor för migrations
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=CodeFirstFirstTry;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

    }
}
