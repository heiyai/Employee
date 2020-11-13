using Employee.Interface;
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
    }
}
