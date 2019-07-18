using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Guesthouse.Core.Domain.Enums;
using Guesthouse.Core.Utils;

namespace Guesthouse.Core.Domain
{
    public class Client : User
    {
        public virtual Invoice Invoice { get; protected set; } 
        public virtual Reservation Reservation { get; protected set;}
        
        public string PhoneNumber { get; protected set; }
        public string ClientRole { get; protected set; }
        public PayWay PayType { get; protected set; } 
        public Guid? ReservationId { get; protected set;}

        protected Client()
        {
        }

        protected Client(Guid id, string firstName, string lastName, string email,
                string password, string phoneNumber, PayWay payType)
                : base(id, firstName, lastName, email, password)
        {
            SetPhoneNumber(phoneNumber);
            ClientRole = ConstValues.CLIENT_DEFAULT_ROLE;
            PayType = payType;    
        }

        public static Client Create(Guid id, string firstName, string lastName, string email,
                string password, string phoneNumber, PayWay payType)
            => new Client(id, firstName, lastName, email, password, phoneNumber, payType); 

        public void SetPhoneNumber(string phoneNumber)
        {
            if (!IsPhoneNumberValid(phoneNumber))
            {
                throw new Exception("PhoneNumber should have format 'xxx-xxx-xxx'.");
            }

            PhoneNumber = phoneNumber;
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            var regex = new Regex(ConstValues.PHONE_NUMBER_REGEX);

            return regex.IsMatch(phoneNumber);
        }          
    }
}