using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHdag7CodeFirst.Data
{
    public class Application
    {
        public void Run()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitializer = new DataInitializer();
                dataInitializer.MigrateAndSeed(dbContext);

                //dbContext.Database.Migrate();
            }

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Console.WriteLine("Create person");
                Console.WriteLine("-------------");
                var inputName = Console.ReadLine();

                Console.WriteLine("Age?");
                var inputAge = int.Parse(Console.ReadLine());

                Console.WriteLine("Shoe size?");
                var inputShoeSize = int.Parse(Console.ReadLine());

                Console.WriteLine("County?");
                var countyId = int.Parse(Console.ReadLine());
                var countyInput = dbContext.County.First(c => c.Id== countyId);

                dbContext.Person.Add(new Person
                {
                    Age = inputAge,
                    Name = inputName,
                    ShoeSize = inputShoeSize,
                    County = countyInput
                });

                dbContext.SaveChanges();

            }

        }
    }
}
