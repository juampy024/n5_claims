using System.Data;

namespace N5_API.Project.UoW
{
    public class UnitOfWork : IUnitOfWork, System.IDisposable
    {
        private IDbTransaction _trx;
        private readonly IDbConnection _conn;
        public UnitOfWork(IDbConnection connection)
        {
            _conn = connection;
        }

        public virtual void BeginTransaction()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _trx = _conn.BeginTransaction();
            }

        }

        public virtual void Complete()
        {
            if (_trx != null)
            {
                _trx.Commit();
            }

        }

        public virtual void Dispose()
        {
            if (_conn?.State == ConnectionState.Open)
            {
                _conn?.Close();
            }
            _trx?.Dispose();
        }

        public virtual void Rollback()
        {
            _trx?.Rollback();
        }

        public virtual void Close()
        {
            _conn?.Close();
        }
    }
}