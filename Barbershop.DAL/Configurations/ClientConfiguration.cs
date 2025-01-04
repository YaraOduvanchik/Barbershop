using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barbershop.DAL.Configurations;

internal class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder
            .HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Client>(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.Notes).IsRequired(false);
    }
}