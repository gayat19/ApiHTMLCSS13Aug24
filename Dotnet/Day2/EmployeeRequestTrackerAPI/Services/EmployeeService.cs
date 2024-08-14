using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeService(IRepository<int,Employee> employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            //Add code for verifying employee emaila nd phone with OTP
            var newEmployee = await _employeeRepository.Add(employee);
            return newEmployee;
        }

        public async Task<Employee> UpdatePhone(int id, long phone)
        {
           var employee = await _employeeRepository.GetById(id);
            if(employee != null)
            {
                if (employee.Phone != phone)
                {
                    employee.Phone = phone;
                    //add code for OTP generation
                    employee = await _employeeRepository.Update(employee);
                    return employee;
                }
                throw new Exception("No need for update");
            }
            throw new Exception("No such employee");
        }
    }
}
