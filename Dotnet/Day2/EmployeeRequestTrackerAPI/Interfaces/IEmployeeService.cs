using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> AddEmployee(Employee employee);
        public Task<Employee> UpdatePhone(int id, long phone);
    }
}
