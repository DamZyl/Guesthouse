using Guesthouse.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesthouse.Infrastructure.Database
{
    public class DbInitializer
    {
        private readonly DatabaseContext _databaseContext;

        public DbInitializer(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task SeedData()
        {
            if (!_databaseContext.Reservations.Any())
            {
                await _databaseContext.AddRangeAsync(_reservations);
                await _databaseContext.SaveChangesAsync();
            }

            if (!_databaseContext.Rooms.Any())
            {
                await _databaseContext.AddRangeAsync(_rooms);
                await _databaseContext.SaveChangesAsync();
            }

            if (!_databaseContext.Conveniences.Any())
            {
                await _databaseContext.AddRangeAsync(_conveninces);
                await _databaseContext.SaveChangesAsync();
            }

            if (!_databaseContext.Clients.Any())
            {
                await _databaseContext.AddRangeAsync(_clients);
                await _databaseContext.SaveChangesAsync();
            }

            if (!_databaseContext.Employees.Any())
            {
                await _databaseContext.AddRangeAsync(_employees);
                await _databaseContext.SaveChangesAsync();
            }

            if (!_databaseContext.Invoices.Any())
            {
                await _databaseContext.AddRangeAsync(_invoices);
                await _databaseContext.SaveChangesAsync();
            }
        }

        List<Room> _rooms = new List<Room>()
        {
            new Room(Guid.NewGuid(), 10, 1, 50),
            new Room(Guid.NewGuid(), 5, 1, 60)
        };

        List<Convenience> _conveninces = new List<Convenience>()
        {
            new Convenience(Guid.NewGuid(), "Hot Water", 10),
            new Convenience(Guid.NewGuid(), "Breakfast", 25)
        };

        List<Employee> _employees = new List<Employee>()
        {
            new Employee(new Guid("313afe18-fb09-4feb-89fc-0a9e6c3bb3f9"), "Marek", "Nowak",
                "marek.nowak@o2.pl", "fahsfjasdhauwaw", Role.Admin),
            new Employee(new Guid("916468ff-5577-4b41-9ba0-7158f7f894e2"), "Jan", "Kowalski",
                "jan.kowalski@outlook.com", "gsfaeadsfasdasda", Role.Employee),
        };

        List<Client> _clients = new List<Client>()
        {
            new Client(new Guid("9a3f404f-b234-4aac-98ec-eb8357d36b28"), "Arek", "Kowal",
                "arek.kowal@gmail.com", "daaksdjawuhaj", "518-907-243", PayWay.Cash),
            new Client(new Guid("72df4af1-b177-4629-8be5-af358a6674b4"), "Robert", "Wojciech",
                "robert.wojciech@gmail.com", "dasdawdfcfad", "435-902-243", PayWay.CreditCard)
        };

        List<Reservation> _reservations = new List<Reservation>()
        {
            new Reservation(new Guid("01b2f819-3d7c-4932-aadb-60a5d0feba9d"), "My reservation",
                DateTime.UtcNow, DateTime.UtcNow.AddDays(2))
        };

        List<Invoice> _invoices = new List<Invoice>()
        {
           new Invoice(Guid.NewGuid(), new Guid("72df4af1-b177-4629-8be5-af358a6674b4"), "Robert Wojciech",
               new Guid("313afe18-fb09-4feb-89fc-0a9e6c3bb3f9"), "Marek Nowak", new Guid("01b2f819-3d7c-4932-aadb-60a5d0feba9d"),
               "My reservation", DateTime.UtcNow, DateTime.UtcNow.AddDays(2), 50M)
        };
    }
}
