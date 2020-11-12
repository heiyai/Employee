using Employee.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee.Service
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(DbContext context):base(context)
        {

        }
        public List<Model.Employee> CacheAllEmployee()
        {
            return base.Set<Model.Employee>().ToList();
        }
    }
}
