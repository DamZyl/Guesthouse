using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guesthouse.Infrastructure.Database.Configurations
{
    public class ReservationConvenienceConfiguration : IEntityTypeConfiguration<ReservationConvenience>
    {
        public void Configure(EntityTypeBuilder<ReservationConvenience> builder)
        {
            builder.HasKey(b => new { b.ReservationId, b.ConvenienceId });
        }
    }
}