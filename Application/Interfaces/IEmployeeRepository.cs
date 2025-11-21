using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        void Remove(Employee employee);

        Task UpdateAsync(Employee employee);
        Task SaveChangesAsync();

        //  Reports
        Task<int> GetTotalEmployeesAsync();
        Task<Dictionary<string, int>> GetEmployeesByPositionAsync();
    }
}
