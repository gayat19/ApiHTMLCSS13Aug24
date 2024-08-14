namespace EmployeeRequestTrackerAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
    }
}
