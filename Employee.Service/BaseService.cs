
using Employee.Interface;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service
{
    public class BaseService : IBaseService
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(int Id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            throw new NotImplementedException();
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T t) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            throw new NotImplementedException();
        }
    }
}