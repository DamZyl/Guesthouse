using System;
using System.Threading.Tasks;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Services.Users.Dto;

namespace Guesthouse.Services.Services
{
    public interface IEmployeeService
    {
        Task<AccountDto> GetAccountAsync(Guid employeeId);
        Task RegisterAsync(Guid id, string firstName, string lastName, string email, 
            string password, string role);
        Task<TokenDto> LoginAsync(string email, string password);
    }
}