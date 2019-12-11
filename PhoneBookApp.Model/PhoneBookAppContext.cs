using PhoneBookApp.Model.Entities.PhoneBook;
using PhoneBookApp.Model.Entities.System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookApp.Model
{
  public class PhoneBookAppContext : DbContext
  {
    //PhoneBook
    public virtual DbSet<PHB_PhoneNumber> PHB_PhoneNumber { get; set; }
    public DbSet<PHB_PhoneBook> PHB_PhoneBook { get; set; }
    //System Tables
    public virtual DbSet<SYS_Error> SYS_Error { get; set; }

    public PhoneBookAppContext(DbContextOptions options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
      {
        relationship.DeleteBehavior = DeleteBehavior.Restrict;
      }

      modelBuilder.ApplyAllConfigurations();

    }
  }
}
