using Guesthouse.Core.Domain;
using Guesthouse.Core.Domain.Enums;

namespace Guesthouse.Services.Users.Commands
{
    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public PayWay PayType { get; set; }
        public string EmployeeRole { get; set; }
    }
}