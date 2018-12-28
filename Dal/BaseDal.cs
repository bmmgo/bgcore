using System.Data;
using System.Data.SqlClient;
using DapperExtensions;
using DI;

namespace Dal
{
    public abstract class BaseDal : ISingleton
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection("Data Source = .;Initial Catalog = db;User Id = dev;Password = dev;");
        }
    }

    public abstract class BaseDal<T> : BaseDal where T : class
    {
        public T Select(dynamic id)
        {
            using (var conn = GetConnection())
            {
                return DapperExtensions.DapperExtensions.Get<T>(conn, id);
            }
        }

        public dynamic Insert(T entity)
        {
            using (var conn = GetConnection())
            {
                return conn.Insert(entity);
            }
        }

        public dynamic Update(T entity)
        {
            using (var conn = GetConnection())
            {
                return conn.Update(entity);
            }
        }

        public bool Delete(dynamic id)
        {
            using (var conn = GetConnection())
            {
                return DapperExtensions.DapperExtensions.Delete<T>(conn, id);
            }
        }

        public bool Delete(T entity)
        {
            using (var conn = GetConnection())
            {
                return conn.Delete(entity);
            }
        }
    }
}
