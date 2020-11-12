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
        private readonly IEmployeeService _iEmployeeService;
        public HomeController(ILogger<HomeController> logger
            ,EmployeeService employeeService)
        {
            _logger = logger;
            _iEmployeeService = employeeService;
        }

        public IActionResult Index()
        {
            //var userList = this._iEmployeeService.QueryPage<Employee.Model.Employee, int>(u => u.EmployeeId > 1, 5, 1, u => u.EmployeeId);
            var user = this._iEmployeeService.Find<Employee.Model.Employee>(1);
            base.ViewBag.FirstName = user.FirstName;

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
