using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookApp.Model.Entities.PhoneBook;

namespace PhoneBookApp.Model.EntityMappings.Lookup
{
  public class PhoneNumberMapping : IEntityTypeConfiguration<PHB_PhoneNumber>
  {
    public void Configure(EntityTypeBuilder<PHB_PhoneNumber> modelBuilder)
    {
      modelBuilder.ToTable("PHB_PhoneNumber", "dbo");

      modelBuilder.HasKey(x => x.id);

      modelBuilder.Property(x => x.name)
          .HasMaxLength(100);
      modelBuilder.Property(s => s.email)
          .HasMaxLength(100);

      modelBuilder.Property(s => s.number)
          .HasMaxLength(100);

      modelBuilder.HasOne(x => x.PhoneBook)
                .WithMany(s => s.PhoneNumbers);

    }
  }
}
