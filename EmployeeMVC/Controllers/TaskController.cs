﻿using Employee.Interface;
using Employee.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EmployeeMVC.Controllers
{
    using T = Employee.Model.Task;
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
            if (HttpContext.Session.GetInt32(app.Tag.EmployeeId) == null)
                HttpContext.Session.SetInt32(app.Tag.EmployeeId, id);
            if (id == 0)
                id = HttpContext.Session.GetInt32(app.Tag.EmployeeId).Value;
            var list = _iTaskService.Query<T>(x => x.EmployeeId == id);
            var employee = _iEmployeeService.Find<Employee.Model.Employee>(id);
            var employeeName = employee.FirstName + employee.LastName;
            ViewBag.EmployeeName = TempData[app.Tag.EmployeeName] = employeeName;
            if (HttpContext.Session.GetInt32(app.Tag.EmployeeName) == null)
                HttpContext.Session.SetString(app.Tag.EmployeeName, employeeName);
            
            ViewBag.EmployeeID = TempData[app.Tag.EmployeeId] = id;
            return View(list);
        }

        [HttpPost]
        public ActionResult IndexByFilter()
        {
            var tName = Request.Form[app.Tag.TaskName];
            var employeeID = HttpContext.Session.GetInt32(app.Tag.EmployeeId);
            var user = this._iTaskService.Query<T>(x => x.TaskName.Contains(tName) && x.EmployeeId == employeeID);
            if (HttpContext.Session.GetInt32(app.Tag.EmployeeName) != null)
            {
                ViewBag.EmployeeName = TempData[app.Tag.EmployeeName] =
                HttpContext.Session.GetString(app.Tag.EmployeeName);
            }
            return View(nameof(Index), user);
        }

        public ActionResult Edit(int id)
        {
            var entity = _iTaskService.Query<T>(x => x.TaskId == id).FirstOrDefault();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                T tk = new T()
                {
                    TaskId = int.Parse(collection[app.Tag.TaskId]),
                    EmployeeId = int.Parse(collection[app.Tag.EmployeeId]),
                    TaskName = collection[app.Tag.TaskName],
                    StartTime = DateTime.Parse(collection[app.Tag.StartTime]),
                    Deadline = DateTime.Parse(collection[app.Tag.DeadLine])
                };
                this._iTaskService.Update<T>(tk);
                return RedirectToAction(nameof(Index), new { id = collection[app.Tag.EmployeeId] });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                T tk = new T()
                {
                    EmployeeId = int.Parse(collection[app.Tag.EmployeeId].ToString()),
                    TaskName = collection[app.Tag.TaskName],
                    StartTime = DateTime.Parse(collection[app.Tag.StartTime]),
                    Deadline = DateTime.Parse(collection[app.Tag.DeadLine])
                };

                var entity = this._iTaskService.Insert<Task>(tk);
                return RedirectToAction(nameof(Index), new { id = int.Parse(collection[app.Tag.EmployeeId].ToString()) });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var entity = _iTaskService.Find<T>(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _iTaskService.Delete<T>(id);
                var a = int.Parse(collection[app.Tag.EmployeeId].ToString());
                return RedirectToAction(nameof(Index), new { id = int.Parse(collection[app.Tag.EmployeeId].ToString()) });
            }
            catch
            {
                return View();
            }
        }
    }
}
