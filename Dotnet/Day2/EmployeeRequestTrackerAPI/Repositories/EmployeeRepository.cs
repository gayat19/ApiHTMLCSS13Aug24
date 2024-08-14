using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch(Exception ex)
            {
                throw new UnableToAddException("Employee");
            }
           
        }

        public async Task<Employee> Delete(int key)
        {
            var myEmployee = await GetById(key);
            if (myEmployee != null)
            {
                _context.Remove(myEmployee);
                _context.SaveChangesAsync();
                return myEmployee;
            }
            throw new Exception("No such employee");
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees.Count>0 ? employees:throw new Exception("No employees");
        }

        public async Task<Employee> GetById(int key)
        {
            var employee = (await GetAll()).FirstOrDefault(e => e.Id == key);
            return employee;
        }

        public async Task<Employee> Update(Employee item)
        {
            var myEmployee = await GetById(item.Id);
            if (myEmployee != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                //_context.Update(item);
                _context.SaveChangesAsync();
                return item;
            }
            throw new Exception("No such employee");
        }
    }
}
