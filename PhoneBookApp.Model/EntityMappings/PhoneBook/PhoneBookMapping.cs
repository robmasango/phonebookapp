using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookApp.Model.Entities.PhoneBook;

namespace PhoneBookApp.Model.EntityMappings.Lookup
{
  public class PhoneBookMapping : IEntityTypeConfiguration<PHB_PhoneBook>
  {
    public void Configure(EntityTypeBuilder<PHB_PhoneBook> modelBuilder)
    {
      modelBuilder.ToTable("PHB_PhoneBook", "dbo");

      modelBuilder.HasKey(c => c.Id);

      modelBuilder.Property(s => s.Name)
          .HasMaxLength(100);

      modelBuilder.HasMany(s => s.PhoneNumbers)
          .WithOne(c => c.PhoneBook);
    }
  }
}
