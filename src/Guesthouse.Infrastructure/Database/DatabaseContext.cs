using Guesthouse.Core.Domain;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<Client>()
                .HasMany<Reservation>(b => b.Reservations)
                .WithOne(b => b.Client)
                .HasForeignKey(b => b.Id);

            builder.Entity<Invoice>()
                .HasMany<Reservation>(b => b.Reservations)
                .WithOne(b => b.Invoice)
                .HasForeignKey(b => b.Id);

            builder.Entity<Invoice>()
                .HasOne<Client>(b => b.Client)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.ClientId);

            builder.Entity<Invoice>()
                .HasOne<Employee>(b => b.Employee)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(b => b.EmployeeId);

            builder.Entity<Client>()
                .HasOne<Invoice>(b => b.Invoice)
                .WithOne(b => b.Client);
            
            builder.Entity<Employee>()
                .HasOne<Invoice>(b => b.Invoice)
                .WithOne(b => b.Employee);

            base.OnModelCreating(builder);
        }
    }
}