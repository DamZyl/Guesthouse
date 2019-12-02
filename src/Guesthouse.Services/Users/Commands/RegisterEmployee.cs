using System;
using Newtonsoft.Json;

namespace Guesthouse.Services.Users.Commands
{
    public class RegisterEmployee : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmployeeRole { get; set; }
        
        [JsonConstructor]
        public RegisterEmployee(Guid id, string firstName, string lastName, string email,
            string password, string employeeRole)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            EmployeeRole = employeeRole;
        }
    }
}