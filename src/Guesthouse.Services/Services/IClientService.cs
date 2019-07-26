using System;
using System.Threading.Tasks;
using Guesthouse.Core.Domain.Enums;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Services.Users.Dto;

namespace Guesthouse.Services.Services
{
    public interface IClientService : IService
    {
        Task<AccountDto> GetAccountAsync(Guid clientId);
        Task RegisterAsync(Guid id, string firstName, string lastName, string email, 
            string password, string phoneNumber, PayWay payType);
        Task<TokenDto> LoginAsync(string email, string password);
    }
}