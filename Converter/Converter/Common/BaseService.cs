using System.Data;
using System.Data.SqlClient;

namespace Converter.Common
{
    public abstract class BaseService
    {

        //Establishing  DBConnections (Dapper) 

        public string _connectionString;
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _dispose;

        protected BaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }
        protected void commit()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Commit();
                }
                catch (Exception)
                {

                    _transaction.Rollback();
                    throw;
                }
                finally
                {
                    _transaction.Dispose();
                    Close();
                }


            }
            else
            {
                Close();
            }
        }
        private void Close()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
        }

        protected void Dispose(bool Disposing)
        {
            if (!_dispose)
            {
                if (Disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;

                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _dispose = true;
            }
        }
        protected void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected IDbTransaction GetTransaction()
        {
            if (_transaction == null)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }

            return _transaction;
        }

        protected void Commit()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Commit();
                }
                catch
                {
                    _transaction.Rollback();
                    throw;
                }
                finally
                {
                    _transaction.Dispose();
                    Close();
                }
            }
            else
            {
                Close();

            }
        }
    }
}
