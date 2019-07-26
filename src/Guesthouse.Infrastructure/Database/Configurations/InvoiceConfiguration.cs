using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guesthouse.Infrastructure.Database.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(b => b.Id);
            
            builder.HasOne<Reservation>(b => b.Reservation)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.ReservationId);

            builder.HasOne<Client>(b => b.Client)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.ClientId);
            
            builder.HasOne<Employee>(b => b.Employee)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.EmployeeId);
        }
    }
}