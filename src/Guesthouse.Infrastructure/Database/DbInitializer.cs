using Guesthouse.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guesthouse.Core.Domain.Enums;
using Guesthouse.Core.Utils;

namespace Guesthouse.Infrastructure.Database
{
    public class DbInitializer // Refactor!!!
    {
        private readonly DatabaseContext _databaseContext;
        
        private List<Room> _rooms = new List<Room>()
        {
            Room.Create(new Guid("1032b803-dcd4-44b0-a994-7fdc367e5de9"), 1, 1, 50),
            Room.Create(new Guid("e1bc7ee0-80d5-41ed-b87b-f3c87c157a85"), 2, 1, 60)
        };

        private List<Convenience> _conveninces = new List<Convenience>()
        {
            Convenience.Create(new Guid("6d46e87d-a988-4271-92db-ceaab4d2853b"), "Hot Water", 10),
            Convenience.Create(new Guid("1877c357-37d0-466a-8919-d7d7a60bc9fe"), "Breakfast", 25)
        };

        private List<Employee> _employees = new List<Employee>()
        {
            Employee.Create(new Guid("313afe18-fb09-4feb-89fc-0a9e6c3bb3f9"), "Marek", "Nowak",
                "marek.nowak@o2.pl", "fahsfjasdhauwaw", Role.Admin),
            Employee.Create(new Guid("916468ff-5577-4b41-9ba0-7158f7f894e2"), "Jan", "Kowalski",
                "jan.kowalski@outlook.com", "gsfaeadsfasdasda", Role.Employee),
        };

        private List<Client> _clients = new List<Client>()
        {
            Client.Create(new Guid("9a3f404f-b234-4aac-98ec-eb8357d36b28"), "Arek", "Kowal",
                "arek.kowal@gmail.com", "daaksdjawuhaj", "518-907-243", PayWay.Cash),
            Client.Create(new Guid("72df4af1-b177-4629-8be5-af358a6674b4"), "Robert", "Wojciech",
                "robert.wojciech@gmail.com", "dasdawdfcfad", "435-902-243", PayWay.CreditCard)
        };

        private List<Reservation> _reservations = new List<Reservation>()
        {
            Reservation.Builder.Create()
                .WithId(new Guid("01b2f819-3d7c-4932-aadb-60a5d0feba9d"))
                .WithDescription("My reservation")
                .WithDates(DateTime.Now, DateTime.Now.AddDays(2))
                .WithReservationStatus()
                .WithPayStatus()
                .Build()
        };

        private List<ReservationRoom> _reservationRooms = new List<ReservationRoom>();

        private List<ReservationConvenience> _reservationConveniences = new List<ReservationConvenience>();
        /*private List<Invoice> _invoices = new List<Invoice>()
        {
            Invoice.Create(Guid.NewGuid(), new Guid("72df4af1-b177-4629-8be5-af358a6674b4"), "Robert Wojciech",
               new Guid("313afe18-fb09-4feb-89fc-0a9e6c3bb3f9"), "Marek Nowak", new Guid("01b2f819-3d7c-4932-aadb-60a5d0feba9d"),
               "My reservation", DateTime.UtcNow, DateTime.UtcNow.AddDays(2), 50M)
        };*/

        public DbInitializer(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            
            _reservationRooms.Add(ReservationRoom.Booked(_reservations.ElementAtOrDefault(0),
                _rooms.ElementAtOrDefault(0)));
            _reservationRooms.Add(ReservationRoom.Booked(_reservations.ElementAtOrDefault(0),
                _rooms.ElementAtOrDefault(1)));
            
            _reservationConveniences.Add(ReservationConvenience.Create(_reservations.ElementAtOrDefault(0),
                _conveninces.ElementAtOrDefault(0)));
            _reservationConveniences.Add(ReservationConvenience.Create(_reservations.ElementAtOrDefault(0),
                _conveninces.ElementAtOrDefault(1)));
        }

        public async Task SeedData()
        {
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

            if (!_databaseContext.Reservations.Any())
            {
                await _databaseContext.AddRangeAsync(_reservations);
                await _databaseContext.SaveChangesAsync();
            }
            
            if (!_databaseContext.ReservationRooms.Any())
            {
                await _databaseContext.AddRangeAsync(_reservationRooms);
                await _databaseContext.SaveChangesAsync();
            }
            
            if (!_databaseContext.ReservationConveniences.Any())
            {
                await _databaseContext.AddRangeAsync(_reservationConveniences);
                await _databaseContext.SaveChangesAsync();
            }

            /*if (!_databaseContext.Invoices.Any())
            {
                await _databaseContext.AddRangeAsync(_invoices);
                await _databaseContext.SaveChangesAsync();
            }*/
        }
    }
}
