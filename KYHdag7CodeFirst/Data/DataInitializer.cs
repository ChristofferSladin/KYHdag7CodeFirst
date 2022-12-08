using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHdag7CodeFirst.Data
{
    public class DataInitializer
    {
        public void SeedCountys(ApplicationDbContext dbContext)
        {

        }
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedCountys(dbContext);
            dbContext.SaveChanges();
        }
         

    }
}
