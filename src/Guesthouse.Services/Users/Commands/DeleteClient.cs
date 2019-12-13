using System;

namespace Guesthouse.Services.Users.Commands
{
    public class DeleteClient : ICommand
    {
        public Guid Id { get; set; }
    }
}