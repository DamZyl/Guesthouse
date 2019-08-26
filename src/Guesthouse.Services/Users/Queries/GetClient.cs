using System;
using Guesthouse.Services.Users.Dto;

namespace Guesthouse.Services.Users.Queries
{
    public class GetClient : IQuery<AccountDto>
    {
        public Guid Id { get; set; }
    }
}