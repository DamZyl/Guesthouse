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
            /*if (!_databaseContext.Reservations.Any())
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
            }*/
        }

        List<Room> _rooms = new List<Room>()
        {
            new Room(Guid.NewGuid(), 10, 1, 50),
            new Room(Guid.NewGuid(), 10, 1, 60)
        };

        List<Convenience> _conveninces = new List<Convenience>()
        {
            new Convenience(Guid.NewGuid(), "Hot Water", 10),
            new Convenience(Guid.NewGuid(), "Breakfast", 25)
        };

        List<Employee> _employees = new List<Employee>()
        {
            new Employee(Guid.NewGuid(), "Marek", "Nowak", "marek.nowak@o2.pl", "fahsfjasdhauwaw", Role.Admin),
            new Employee(Guid.NewGuid(), "Jan", "Kowalski", "jan.kowalski@outlook.com", "gsfaeadsfasdasda", Role.Employee),
        };

        List<Client> _clients = new List<Client>()
        {
            new Client(Guid.NewGuid(), "Arek", "Kowal", "arek.kowal@gmail.com", "daaksdjawuhaj", "518-907-243", PayWay.Cash),
            new Client(Guid.NewGuid(), "Robert", "Wojciech", "robert.wojciech@gmail.com", "dasdawdfcfad", "435-902-243", PayWay.CreditCard)
        };

        List<Reservation> _reservations = new List<Reservation>()
        {
            new Reservation(Guid.NewGuid(), "My reservation", DateTime.UtcNow, DateTime.UtcNow.AddDays(2))
        };

        List<Invoice> _invoices = new List<Invoice>()
        {
           new Invoice(Guid.NewGuid(), new Guid("a7b43a9b-79e9-49fe-9af0-81c3d6f0d226"), "Robert Wojciech",
               new Guid("6f6b8717-cb93-4830-aae6-49223c79aa3d"), "Marek Nowak", new Guid("b89dfa5e-236a-41c4-b5e4-fb7c2c5eac70"),
               "My reservation", DateTime.UtcNow, DateTime.UtcNow.AddDays(2), 50M)
        };
    }
}
