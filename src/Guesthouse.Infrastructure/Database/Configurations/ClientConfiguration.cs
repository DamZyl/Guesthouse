using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guesthouse.Infrastructure.Database.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(b => b.Id);
            
            builder.HasOne(b => b.Reservation)
                .WithOne(b => b.Client)
                .HasForeignKey<Client>(b => b.ReservationId);

            builder.HasOne(b => b.Invoice)
                .WithOne(b => b.Client);

            builder.Property(p => p.PayType)
                .HasConversion<string>();
        }
    }
}