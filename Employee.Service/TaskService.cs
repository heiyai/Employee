using Employee.Interface;
using Microsoft.EntityFrameworkCore;
using Employee.Model;
using System;

namespace Employee.Service
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(DbContext context) : base(context)
        {
        }

        public void DeleteByEmployeeID<Task>(int employeeID)
        {

            var tasks = this.Query<Employee.Model.Task>(x => x.EmployeeId == employeeID);
            if (tasks == null) return;
            this.Context.RemoveRange(tasks);
            this.Commit();

        }
    }
}
