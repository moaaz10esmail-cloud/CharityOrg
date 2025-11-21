using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CharityDbContext _context;

        public EmployeeRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _context.Employees.FindAsync(id);

        public async Task<List<Employee>> GetAllAsync() =>
            await _context.Employees.ToListAsync();

        public async Task AddAsync(Employee employee) =>
            await _context.Employees.AddAsync(employee);

        public void Remove(Employee employee) =>
            _context.Employees.Remove(employee);


        public async Task UpdateAsync(Employee employee) =>
            await Task.Run(() => _context.Employees.Update(employee));

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        // Reports
        public async Task<int> GetTotalEmployeesAsync() =>
            await _context.Employees.CountAsync();

        public async Task<Dictionary<string, int>> GetEmployeesByPositionAsync() =>
            await _context.Employees
                .GroupBy(e => e.Position)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
    }
}
