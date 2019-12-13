using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guesthouse.Infrastructure.Database.Configurations
{
    public class ConvenienceConfiguration : IEntityTypeConfiguration<Convenience>
    {
        public void Configure(EntityTypeBuilder<Convenience> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasMany(b => b.Reservations)
                .WithOne(b => b.Convenience)
                .HasForeignKey(b => b.ConvenienceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}