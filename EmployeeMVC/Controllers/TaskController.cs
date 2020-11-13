using Employee.Interface;
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
        private readonly DbContext _dbContext;

        public TaskController(ILogger<TaskController> logger
           , ILoggerFactory loggerFactory
           , ITaskService taskService
           , DbContext dbContext
           )
        {
            _logger = logger;
            this._loggerFactory = loggerFactory;
            this._iTaskService = taskService;
            this._dbContext = dbContext;
        }
        public IActionResult Index(int employeeID)
        {
            return View();
        }
    }
}
