using N5_API.Project.Repositories.PostgreSql.Interfaces;
using System.Collections.Generic;

namespace N5_API.Project.UoW
{
    public interface IUnitOfWork
    {
        #region Services Interfaces

        #endregion
        #region Transactions
        void BeginTransaction();
        void Complete();
        void Dispose();
        void Rollback();
        void Close();
        #endregion
    }
}