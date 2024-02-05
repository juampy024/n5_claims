using Microsoft.EntityFrameworkCore;
using N5_API.Project.Repositories;
using N5_API.Project.Repositories.SQLServer;


namespace N5_API.Project.UoW
{
    public class UnitOfWorkSql : IUnitOfWorkSql, IDisposable
    {
        private readonly N5Context _context;
        private bool disposed;

        public UnitOfWorkSql(N5Context context)
        {
            this._context = context;
        }

        /// <summary>
        /// Generic methods starts here
        /// </summary>
        /// 
        public void InitializePerson()
        {
            if(Person == null) Person = new PersonRepository(_context);
        }   
        public IPersonRepository Person { get; private set; }

        public void InitializeEmployee()
        {
            if(Employee == null) Employee = new EmployeeRepository(_context);
        }

        public IEmployeeRepository Employee { get; private set; }


        public void InitializePermission()
        { 
            if(Permission == null) Permission = new PermissionRepository(_context);
        }
        public IPermissionRepository Permission { get; private set; }

        public void InitializePermissionType()
        {
            if(PermissionType == null) PermissionType = new PermissionTypeRepository(_context);
        }
        public IPermissionTypeRepository PermissionType { get; private set; }

        public virtual async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public virtual async Task CloseConnection()
        {
            await _context.Database.CloseConnectionAsync();
        }

        public virtual async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
            await _context.Database.CurrentTransaction?.CommitAsync();
        }

        public virtual async Task RollbackAsync()
        {
            if(_context.Database.CurrentTransaction != null) await _context.Database.CurrentTransaction?.RollbackAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //_context.Database.CurrentTransaction?.Dispose();
                    _context.Dispose();
                }

                disposed = true;
            }
        }
    }
}
