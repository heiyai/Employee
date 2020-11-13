using Employee.Interface;
using Employee.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace EmployeeMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITaskService _iTaskService;
        private readonly IEmployeeService _iEmployeeService;
        private readonly DbContext _dbContext;

        public TaskController(ILogger<TaskController> logger
           , ILoggerFactory loggerFactory
           , ITaskService taskService
           , IEmployeeService employeeService
           , DbContext dbContext
           )
        {
            _logger = logger;
            this._loggerFactory = loggerFactory;
            this._iTaskService = taskService;
            this._iEmployeeService = employeeService;
            this._dbContext = dbContext;
        }
        public IActionResult Index(int id)
        {
            var list = _iTaskService.Query<Task>(x => x.EmployeeId == id);
            var employee = _iEmployeeService.Find<Employee.Model.Employee>(id);
            ViewBag.EmployeeName = employee.FirstName + employee.LastName;
            return View(list);
        }
    }
}
