using Employee.Interface;
using Employee.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Employee.Service
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(DbContext context) : base(context)
        {

        }
        public List<Model.Employee> CacheAllEmployee()
        {
            return base.Set<Model.Employee>().ToList();
        }

        public override void Delete<T>(int Id)
        {
            Model.Employee e = this.Find<Model.Employee>(Id);
            if (e == null) return;

            var tasks = this.Query<Task>(x => x.EmployeeId == Id);
            if (tasks != null)
            {
                this.Context.RemoveRange(tasks);
            }
            this.Context.Set<Model.Employee>().Remove(e);
            this.Commit();
        }
    }
}
