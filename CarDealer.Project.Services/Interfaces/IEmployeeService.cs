using N5_API.Project.Models;
namespace N5_API.Project.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee?> Create(Employee employee);
        Task<Employee?> Delete(int id);
        Task<Employee?> Update(Employee employee);
        Task<Employee?> GetById(int id);

        void Dispose();

    }
}
