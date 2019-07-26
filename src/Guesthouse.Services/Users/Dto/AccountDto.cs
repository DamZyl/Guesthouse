using System;

namespace Guesthouse.Services.Users.Dto
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}