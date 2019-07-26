using Guesthouse.Core.Domain;
using Guesthouse.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Guesthouse.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IOptions<SqlOptions> _sqlOptions;
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Convenience> Conveniences { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        
        public DatabaseContext(IOptions<SqlOptions> sqlOptions)
        {
            _sqlOptions = sqlOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(_sqlOptions.Value.ConnectionString,
                o => o.MigrationsAssembly("Guesthouse.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ConvenienceConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}