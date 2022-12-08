using KYHdag7CodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();

var options = new DbContextOptionsBuilder<ApplicationDbContext>();
var connectionString = config.GetConnectionString("DefaultConnection");
options.UseSqlServer(connectionString);

using (var dbContext = new ApplicationDbContext(options.Options))
{
    dbContext.Database.Migrate();
}