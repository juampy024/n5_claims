using Microsoft.EntityFrameworkCore;
using N5_API.Project.Models;


namespace N5_API.Project.Repositories.SQLServer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly N5Context _context;
        public EmployeeRepository(N5Context context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> DeleteEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            try
            {
               
                var employee = await _context.Employee
                    .Include(e => e.Person) 
                    .Include(e => e.PermissionEmployees) 
                        .ThenInclude(pe => pe.Permission) 
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                {
                     throw new ArgumentNullException(nameof(employee));
                }
                return employee;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }

                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }
    }
}
