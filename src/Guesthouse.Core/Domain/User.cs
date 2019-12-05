using System;
using System.ComponentModel.DataAnnotations;
using Guesthouse.Core.Extensions;
using Guesthouse.Core.Utils;
using Guesthouse.Core.Utils.Exceptions;

namespace Guesthouse.Core.Domain
{
    public abstract class User
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        protected User() { }

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
                throw new DomainException(ErrorCodes.InvalidFirstName, "FirstName should not be empty.");
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
                throw new DomainException(ErrorCodes.InvalidLastName, "LastName should not be empty.");
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
                throw new DomainException(ErrorCodes.InvalidEmail, "Email should not be empty.");
            }

            if (!new EmailAddressAttribute().IsValid(email))
            {
                throw new DomainException(ErrorCodes.InvalidEmail, "Email does not match the EmailPattern.");
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
                throw new DomainException(ErrorCodes.InvalidPassword, "Password should not be empty.");
            }

            if (password.Length < ConstValues.PASSWORD_MIN_LENGTH)
            {
                throw new DomainException(ErrorCodes.InvalidPassword, $"Password should be greather than {ConstValues.PASSWORD_MIN_LENGTH}");
            }

            if (password.Length > ConstValues.PASSWORD_MAX_LENGTH)
            {
                throw new DomainException(ErrorCodes.InvalidPassword, $"Password should be shorter than {ConstValues.PASSWORD_MAX_LENGTH}");
            }
            
            if (Password == password)
            {
                return;
            }

            Password = password;
        }
    }
}