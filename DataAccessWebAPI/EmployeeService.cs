using EmployeeManagement.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace EmployeeManagement.Services.WebAPI
{
    public class EmployeeService : IEmployeeService
    {
        public string URL { get; set; } = "http://localhost:5042/Employee/";

        private static HttpClient client = new HttpClient();

        public List<Employee> ListEmployees()
        {
            return client.GetFromJsonAsync<List<Employee>>(URL + "List").Result;
        }

        public Employee GetEmployee(int? id)
        {
            return client.GetFromJsonAsync<Employee>(URL + $"Get/{id}").Result;
        }

        public int EditEmployee(Employee currEmp)
        {
            var response = client.PostAsJsonAsync<Employee>(URL + $"Edit", currEmp).Result;
            return JsonSerializer.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
        }

        public int DeleteEmployee(int? id)
        {
            return client.GetFromJsonAsync<int>(URL + $"Delete/{id}").Result;
        }

        public int CreateEmployee(Employee newItem)
        {
            var response = client.PostAsJsonAsync<Employee>(URL + $"Create", newItem).Result;
            return JsonSerializer.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
        }

    }
}