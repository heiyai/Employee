using Employee.Interface;
using Microsoft.EntityFrameworkCore;

namespace Employee.Service
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(DbContext context) : base(context)
        {
        }
    }
}
