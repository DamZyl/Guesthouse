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
        }
    }
}