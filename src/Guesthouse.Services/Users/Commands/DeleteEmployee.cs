using System;

namespace Guesthouse.Services.Users.Commands
{
    public class DeleteEmployee : ICommand
    {
        public Guid Id { get; set; }
    }
}