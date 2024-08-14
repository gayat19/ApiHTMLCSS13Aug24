using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        { 
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                employee = await _employeeService.AddEmployee(employee);
                return Created("", employee);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //converting to dynamic calls based on workloads - later
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployeePhone(Employee employee)//DTO to be replaced
        {
            try
            {
                employee = await _employeeService.UpdatePhone(employee.Id,employee.Phone);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
