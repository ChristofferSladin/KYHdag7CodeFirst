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

                foreach (var county in dbContext.County)
                {
                    Console.WriteLine($"{county.Id} {county.Name}");
                }

                Console.WriteLine("County?");
                var countyId = int.Parse(Console.ReadLine());
                var countyInput = dbContext.County.First(c => c.Id == countyId);

                dbContext.Person.Add(new Person
                {
                    Age = inputAge,
                    Name = inputName,
                    ShoeSize = inputShoeSize,
                    County = countyInput
                });

                dbContext.SaveChanges();

            }

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Console.WriteLine("Read persons");
                Console.WriteLine("------------");

                foreach (var person in dbContext.Person.Include(p => p.County))
                {
                    Console.WriteLine($"name: {person.Name}");
                    Console.WriteLine($"age: {person.Age}");

                    if (person.County != null)
                    {
                        Console.WriteLine($"County contact person: {person.County.ContactPerson}");
                    }
                }
            }

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Console.WriteLine("(U)PDATE en befintlig person");
                Console.WriteLine("=====================");

                // Vilken person ska uppdateras?
                foreach (var person in dbContext.Person)
                {
                    Console.WriteLine($"Id: {person.PersonId}");
                    Console.WriteLine($"Namn: {person.Name}");
                    Console.WriteLine("====================");
                }

                Console.WriteLine("Välj Id på den Person som du vill uppdatera");
                var personIdToUpdate = Convert.ToInt32(Console.ReadLine());
                var personToUpdate = dbContext.Person.First(p => p.PersonId == personIdToUpdate);

                // Uppdatera korrekt person
                Console.WriteLine("Ange namn: ");
                var nameUpdate = Console.ReadLine();

                Console.WriteLine("Ange ålder: ");
                var ageUpdate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ange skostorlek: ");
                var shoeSizeUpdate = Convert.ToInt32(Console.ReadLine());

                foreach (var county in dbContext.County)
                {
                    Console.WriteLine($"{county.Id} - {county.Name}");
                }
                Console.WriteLine("Ange Id på County");
                var countyIdUpdate = Convert.ToInt32(Console.ReadLine());
                var countyUpdate = dbContext.County.First(c => c.Id == countyIdUpdate);

                // Mappar input info till rätt person
                personToUpdate.Age = ageUpdate;
                personToUpdate.Name = nameUpdate;
                personToUpdate.ShoeSize = shoeSizeUpdate;
                personToUpdate.County = countyUpdate;
                dbContext.SaveChanges();
            }
        }



    }
}

