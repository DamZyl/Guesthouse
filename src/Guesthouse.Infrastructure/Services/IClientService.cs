using System;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Domain.Enums;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Services
{
    public interface IClientService
    {
        Task<AccountDto> GetAccountAsync(Guid clientId);
        Task RegisterAsync(Guid id, string firstName, string lastName, string email, 
            string password, string phoneNumber, PayWay payType);
        Task<TokenDto> LoginAsync(string email, string password);
    }
}