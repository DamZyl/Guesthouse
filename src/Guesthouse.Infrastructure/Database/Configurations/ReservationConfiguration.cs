using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guesthouse.Infrastructure.Database.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasMany<Convenience>(b => b.Conveniences)
                .WithOne(b => b.Reservation)
                .HasForeignKey(b => b.ReservationId);

            builder.HasMany<Room>(b => b.Rooms)
                .WithOne(b => b.Reservation)
                .HasForeignKey(b => b.ReservationId);

            builder.HasOne<Invoice>(b => b.Invoice)
                .WithOne(b => b.Reservation);
            
            builder.HasOne<Client>(b => b.Client)
                .WithOne(b => b.Reservation);
            
            builder.Property(p => p.ReservationStatus)
                .HasConversion<string>();

            builder.Property(p => p.PayStatus)
                .HasConversion<string>();
        }
    }
}