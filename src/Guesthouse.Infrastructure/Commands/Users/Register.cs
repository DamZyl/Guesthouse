using Guesthouse.Core.Domain;

namespace Guesthouse.Infrastructure.Commands.Users
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