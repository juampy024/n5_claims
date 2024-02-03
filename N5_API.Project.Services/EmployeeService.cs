using N5_API.Project.Models;
using N5_API.Project.Services.Interfaces;
using N5_API.Project.UoW;

namespace N5_API.Project.Services
{
    public class EmployeeService : IEmployeeService
    {   
        IUnitOfWorkSql _uow;
        public EmployeeService(IUnitOfWorkSql uow) {

            _uow = uow;
            _uow.InitializeEmployee();
        }
 

        public void Dispose()
        {
            _uow.Dispose();
        }
        public async Task<Employee?> Create(Employee employee)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                var result = await _uow.Employee.CreateEmployee(employee);
                await _uow.CompleteAsync();
                return result;
            }
            catch (Exception ex)
            {
                string exceptionDetails = ExceptionHelper.IdentifyException(ex);
                throw new Exception(exceptionDetails);
            }
        }
        public async Task<Employee?> GetById(int id)
        {
            var employee = await _uow.Employee.GetEmployeeById(id);

            return employee;
        }
        public async Task<Employee?> Update(Employee employee)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var employeeToUpdate = await _uow.Employee.GetEmployeeById(employee.Id);

                // add concurrency check here
                if (employeeToUpdate == null) return null;

                employee.LastUpdated = DateTime.Now;
                var employeeUpdated = await _uow.Employee.UpdateEmployee(employee);

                await _uow.BeginTransactionAsync();

                return employeeUpdated;

            }catch(Exception ex)
            {
                string exceptionDetails = ExceptionHelper.IdentifyException(ex);
                throw new Exception(exceptionDetails);
            }
        }
        public async Task<Employee?> Delete(int id)
        {
            await _uow.BeginTransactionAsync();
            var employee = await _uow.Employee.GetEmployeeById(id);

            if(employee == null)
            {
                throw new Exception("Employee not found try again");
            }
            employee.DeletedDate = DateTime.Now;
            var employeeDeleted = await _uow.Employee.DeleteEmployee(employee);
            await _uow.CompleteAsync();
            return employeeDeleted;

        }
    }
}
