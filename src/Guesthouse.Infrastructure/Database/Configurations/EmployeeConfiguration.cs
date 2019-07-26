using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guesthouse.Infrastructure.Database.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Invoice)
                .WithOne(b => b.Employee);
        }
    }
}