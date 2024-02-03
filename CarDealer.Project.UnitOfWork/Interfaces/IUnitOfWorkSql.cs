using N5_API.Project.Repositories.SQLServer;

namespace N5_API.Project.UoW
{
    public interface IUnitOfWorkSql : IDisposable
    {
        #region Interfaces Services
        
        public IEmployeeRepository Employee { get; }
        public IPersonRepository Person { get; }
        public IPermissionRepository Permission { get; }

        public IPermissionTypeRepository PermissionType { get; }

        void InitializePerson();
        void InitializeEmployee();
        void Initializepermission();
        void InitializePermissionType();
        #endregion
        #region Transactions
        Task BeginTransactionAsync();
        Task CompleteAsync();
        Task RollbackAsync();
        #endregion
    }
}