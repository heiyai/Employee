﻿using Employee.Interface;
using Employee.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Linq;

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
            TempData[app.Tag.EmployeeName] = employee.FirstName + employee.LastName;
            TempData[app.Tag.EmployeeId] = id;
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            var entity = _iTaskService.Query<Task>(x => x.TaskId == id).FirstOrDefault();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Task tk = new Task()
                {
                    TaskId = int.Parse(collection[app.Tag.TaskId]),
                    EmployeeId = int.Parse(collection[app.Tag.EmployeeId]),
                    TaskName = collection[app.Tag.TaskName],
                    StartTime = DateTime.Parse(collection[app.Tag.StartTime]),
                    Deadline = DateTime.Parse(collection[app.Tag.DeadLine])
                };
                this._iTaskService.Update<Task>(tk);
                return RedirectToAction(nameof(Index), new { id = collection[app.Tag.EmployeeId]});
            }
            catch 
            {
                return View();
            }
        }
    }
}
