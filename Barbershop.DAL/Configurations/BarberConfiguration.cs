using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Barbershop.DAL.Configurations;

internal class BarberConfiguration : IEntityTypeConfiguration<Barber>
{
    public void Configure(EntityTypeBuilder<Barber> builder)
    {
        builder.ToTable("Barber");
        builder.Property(e => e.SkillLevel).HasConversion(new EnumToStringConverter<SkillLevel>());

        builder
            .HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Barber>(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}