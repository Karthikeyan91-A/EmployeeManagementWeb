using Employee_Management_Web.Models;

namespace Employee_Management_Web.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(int id,Employee employee);
        Task DeleteEmployeeAsync(int id);

        Task<List<Department>> GetDepartmentsAsync();
    }
}
