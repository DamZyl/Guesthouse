using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Guesthouse.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EmployeeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Employee> GetAsync(Guid id)
            => await _databaseContext.Employees.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Employee> GetAsync(string email)
            => await _databaseContext.Employees.SingleOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<Employee>> GetAllAsync()
            => await _databaseContext.Employees.ToListAsync();

        public async Task AddAsync(Employee employee)
            => await _databaseContext.Employees.AddAsync(employee);

        public async Task UpdateAsync(Employee employee)
        {
            _databaseContext.Employees.Update(employee);
            await Task.CompletedTask;
        }


        public async Task DeleteAsync(Employee employee)
        {
            _databaseContext.Employees.Remove(employee);
            await Task.CompletedTask;
        }
    }
}