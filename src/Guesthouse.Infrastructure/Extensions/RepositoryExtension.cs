using System;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;

namespace Guesthouse.Infrastructure.Extensions
{
    // Refactor Repo -> UnitOfWork!!!
    public static class RepositoryExtension
    {
        public static async Task<Reservation> GetOrFailAsync(this IReservationRepository repository, Guid id)
        {
            var reservation = await repository.GetAsync(id);

            if (reservation == null)
            {
                throw new Exception($"Reservation with id: '{id}' does not exist.");
            }

            return reservation;
        }

        public static async Task<Client> GetOrFailAsync(this IClientRepository repository, Guid id)
        {
            var client = await repository.GetAsync(id);

            if (client == null)
            {
                throw new Exception($"Client with id: '{id}' does not exist.");
            }

            return client;
        }
        
        public static async Task<Client> GetOrFailAsync(this IClientRepository repository, string email)
        {
            var client = await repository.GetAsync(email);

            if (client != null)
            {
                throw new Exception($"Client with email: '{email}' already exists.");
            }

            return client;
        }
        
        public static async Task<Employee> GetOrFailAsync(this IEmployeeRepository repository, Guid id)
        {
            var employee = await repository.GetAsync(id);

            if (employee == null)
            {
                throw new Exception($"Employee with id: '{id}' does not exist.");
            }

            return employee;
        }
        
        public static async Task<Employee> GetOrFailAsync(this IEmployeeRepository repository, string email)
        {
            var employee = await repository.GetAsync(email);

            if (employee != null)
            {
                throw new Exception($"Employee with email: '{email}' already exists.");
            }

            return employee;
        }

        public static async Task<Invoice> GetOrFailAsync(this IInvoiceRepository repository, Guid id)
        {
            var invoice = await repository.GetAsync(id);

            if (invoice == null)
            {
                throw new Exception($"Invoice with id: '{id}' does not exist.");
            }

            return invoice;
        }
    }
}