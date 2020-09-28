using PhoneBookApp.Model.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneBookApp.Model.EntityMappings.System
{
    public class ErrorMapping : IEntityTypeConfiguration<SYS_Error>
    {
        public void Configure(EntityTypeBuilder<SYS_Error> modelBuilder)
        {
            modelBuilder.ToTable("SYS_Error", "dbo");

            modelBuilder.HasKey(x => x.Id);

            modelBuilder.Property(x => x.Message)
                .HasMaxLength(100);

            modelBuilder.Property(x => x.StackTrace)
                .HasMaxLength(8000);

            modelBuilder.Property(s => s.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Property(s => s.IsDeleted);
        }
    }
}
