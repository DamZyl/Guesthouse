using System;
using System.ComponentModel.DataAnnotations;
using Guesthouse.Core.Extensions;
using Guesthouse.Core.Utils;

namespace Guesthouse.Core.Domain
{
    public abstract class User
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        protected User()
        {
        }

        protected User(Guid id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
        }

        public string GetFullName()
            => $"{FirstName} {LastName}";

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception();
            }

            firstName = firstName.ToUppercaseFirstInvariant();
            
            if (FirstName == firstName)
            {
                return;
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception();
            }

            lastName = lastName.ToUppercaseFirstInvariant();
            
            if (LastName == lastName)
            {
                return;
            }

            LastName = lastName;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception();
            }

            if (!new EmailAddressAttribute().IsValid(email))
            {
                throw new Exception();
            }
            
            if (Email == email)
            {
                return;
            }

            Email = email;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception();
            }

            if (password.Length < ConstValues.PASSWORD_MIN_LENGTH)
            {
                throw new Exception();
            }

            if (password.Length > ConstValues.PASSWORD_MAX_LENGTH)
            {
                throw new Exception();
            }
            
            if (Password == password)
            {
                return;
            }

            Password = password;
        }
    }
}