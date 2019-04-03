using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Guesthouse.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Convenience> Conveniences { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasKey(b => b.Id);

            builder.Entity<Convenience>()
                .HasKey(b => b.Id);

            builder.Entity<Employee>()
                .HasKey(b => b.Id);

            builder.Entity<Invoice>()
                .HasKey(b => b.Id);

            builder.Entity<Reservation>()
                .HasKey(b => b.Id);

            builder.Entity<Room>()
                .HasKey(b => b.Id);

            builder.Entity<Reservation>()
                .HasMany<Convenience>(b => b.Conveniences)
                .WithOne(b => b.Reservation)
                .HasForeignKey(b => b.Id);

            builder.Entity<Reservation>()
                .HasMany<Room>(b => b.Rooms)
                .WithOne(b => b.Reservation)
                .HasForeignKey(b => b.Id);

            builder.Entity<Invoice>()
                .HasOne<Reservation>(b => b.Reservation)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.ReservationId);

            builder.Entity<Reservation>()
                .HasOne<Invoice>(b => b.Invoice)
                .WithOne(b => b.Reservation);

            builder.Entity<Client>()
                .HasOne<Reservation>(b => b.Reservation)
                .WithOne(b => b.Client)
                .HasForeignKey<Client>(b => b.ReservationId);

            builder.Entity<Reservation>()
                .HasOne<Client>(b => b.Client)
                .WithOne(b => b.Reservation);

            builder.Entity<Invoice>()
                .HasOne<Client>(b => b.Client)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.ClientId);

            builder.Entity<Client>()
                .HasOne<Invoice>(b => b.Invoice)
                .WithOne(b => b.Client);

            builder.Entity<Invoice>()
                .HasOne<Employee>(b => b.Employee)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.EmployeeId);

            builder.Entity<Employee>()
                .HasOne<Invoice>(b => b.Invoice)
                .WithOne(b => b.Employee);

            builder.Entity<Client>()
                .Property(p => p.PayType)
                .HasConversion<string>();

            base.OnModelCreating(builder);
        }
    }
}