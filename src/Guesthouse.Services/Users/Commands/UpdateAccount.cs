using System;
using Newtonsoft.Json;

namespace Guesthouse.Services.Users.Commands
{
    public class UpdateAccount : ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonConstructor]
        public UpdateAccount(Guid id, string email, string password)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Email = email;
            Password = password;
        }
    }
}