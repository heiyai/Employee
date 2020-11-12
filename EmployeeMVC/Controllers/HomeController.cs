using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Employee.Model;
using Microsoft.EntityFrameworkCore;
using Employee.Interface;
using Employee.Service;

namespace EmployeeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IEmployeeService _iEmployeeService;
        private readonly DbContext _dbContext;
        public HomeController(ILogger<HomeController> logger
            , ILoggerFactory loggerFactory
            , IEmployeeService employeeService
            , DbContext dbContext
            )
        {
            _logger = logger;
            this._loggerFactory = loggerFactory;
            this._iEmployeeService = employeeService;
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            this._loggerFactory.CreateLogger<HomeController>().LogWarning("This is FirstController-Index 1");
            #region 测试Context
            //using (InterviewContext context = new InterviewContext())
            //{
            //    base.ViewBag.Name = context.Set<Employee.Model.Employee>().Find(1).FirstName;
            //}
            //base.ViewBag.Name = _dbContext.Set<Employee.Model.Employee>().Find(1).FirstName;
            #endregion
            

            var user = this._iEmployeeService.Find<Employee.Model.Employee>(1);
            base.ViewBag.Name = user.FirstName;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
