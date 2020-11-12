using Employee.Interface.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Service
{
    public class TaskService : BaseService,ITaskService
    {
        public TaskService(DbContext context) : base(context)
        {
        }
    }
}
