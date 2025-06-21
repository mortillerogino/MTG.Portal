
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace MTG.Database.DBContexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine("Current Dir: " + Directory.GetCurrentDirectory());

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<AppDbContextFactory>()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
