using N5_API.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.SQLServer
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(Employee employee);
        Task<Employee?> GetEmployeeById(int id);

    }
}
