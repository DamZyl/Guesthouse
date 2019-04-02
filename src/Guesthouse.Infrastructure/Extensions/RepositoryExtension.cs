using System;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;

namespace Guesthouse.Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static async Task<Reservation> GetOrFailAsync(this IReservationRepository repository, Guid id)
        {
            var reservation = await repository.GetAsync(id);

            if (reservation == null)
            {
                throw new Exception();
            }

            return reservation;
        }

        public static async Task<Client> GetOrFailAsync(this IClientRepository repository, Guid id)
        {
            var client = await repository.GetAsync(id);

            if (client == null)
            {
                throw new Exception();
            }

            return client;
        }
    }
}