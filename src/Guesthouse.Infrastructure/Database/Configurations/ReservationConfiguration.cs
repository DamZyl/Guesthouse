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
            
            builder.HasOne(b => b.Client)
                .WithOne(b => b.Reservation)
                .HasForeignKey<Reservation>(b => b.ClientId);

            builder.HasMany(b => b.Rooms)
                .WithOne(b => b.Reservation)
                .HasForeignKey(b => b.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(b => b.Conveniences)
                .WithOne(b => b.Reservation)
                .HasForeignKey(b => b.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(p => p.ReservationStatus)
                .HasConversion<string>();

            builder.Property(p => p.PayStatus)
                .HasConversion<string>();
        }
    }
}