using System;
using Guesthouse.Core.Domain.Enums;
using Newtonsoft.Json;

namespace Guesthouse.Services.Users.Commands
{
    public class RegisterClient : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public PayWay PayType { get; set; }

        [JsonConstructor]
        public RegisterClient(Guid id, string firstName, string lastName, string email,
            string password, string phoneNumber, PayWay payType)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            PayType = payType;
        }
    }
}