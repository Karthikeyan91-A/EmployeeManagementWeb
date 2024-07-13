namespace Employee_Management_Web.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
