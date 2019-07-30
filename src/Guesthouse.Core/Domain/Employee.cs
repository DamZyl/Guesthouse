using System;
using System.Collections.Generic;
using Guesthouse.Core.Extensions;
using Guesthouse.Core.Utils.Exceptions;

namespace Guesthouse.Core.Domain
{
    public class Employee : User
    {
        public virtual Invoice Invoice { get; protected set; }
        private List<string> _roles = new List<string>()
        {
            Role.Admin, Role.Employee, Role.User
        };

        public string EmployeeRole { get; protected set; }

        protected Employee()
        {
        }

        protected Employee(Guid id, string firstName, string lastName, string email,
                string password, string role) : base(id, firstName, lastName, email, password)
        {
            SetRole(role);
        }

        public static Employee Create(Guid id, string firstName, string lastName, string email,
                string password, string role)
            => new Employee(id, firstName, lastName, email, password, role);

        public void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new DomainException(ErrorCodes.InvalidRole, "Role should not be empty.");
            }

            role = role.ToUppercaseFirstInvariant();

            if (EmployeeRole == role)
            {
                return;
            }

            if (!_roles.Contains(role))
            {
                throw new DomainException(ErrorCodes.InvalidRole, "Role should be chosen from RoleList('ADMIN, USER, EMPLOYEE').");
            }

            EmployeeRole = role;
        }
    }
}