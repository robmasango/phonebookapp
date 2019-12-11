using PhoneBookApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PhoneBookApp.Web
{
  public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PhoneBookAppContext>
  {
    public PhoneBookAppContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PhoneBookAppContext>();

      var connectionString = configuration.GetConnectionString("PhoneBookDb");

      builder.UseSqlServer(connectionString);

      return new PhoneBookAppContext(builder.Options);
    }
  }
}