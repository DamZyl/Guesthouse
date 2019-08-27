using System;
using Guesthouse.Services.Users.Dto;

namespace Guesthouse.Services.Users.Queries
{
    public class GetEmployee : IQuery<AccountDto>
    {
        public Guid Id { get; set; }
    }
}