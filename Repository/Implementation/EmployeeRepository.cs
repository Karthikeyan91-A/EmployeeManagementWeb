using Employee_Management_Web.Models;
using Employee_Management_Web.Repository.Interface;

namespace Employee_Management_Web.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;

        public EmployeeRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("TestClient");
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var response = await _httpClient.GetAsync("api/employees");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Employee>>();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/employees/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/employees", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEmployeeAsync(int id,Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/employees/{employee.EmployeeId}", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/employees/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var response = await _httpClient.GetAsync("api/departments");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Department>>();
        }
    }
}
