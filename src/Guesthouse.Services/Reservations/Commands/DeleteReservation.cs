using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Reservations.Commands
{
    public class DeleteReservation : ICommand
    {
        public Guid Id { get; set; }
    }
}
