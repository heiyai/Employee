using Employee.Interface;
using Employee.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeMVC.Controllers
{/// <summary>
/// Employee管理
/// </summary>
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IEmployeeService _iEmployeeService;
        private readonly DbContext _dbContext;

        public EmployeeController(ILogger<EmployeeController> logger
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
        // GET: EmployeeController


        public ActionResult Index()
        {
            var users = this._iEmployeeService.Set<Employee.Model.Employee>().Where(x => (State)x.State == State.Nomal);
            return View(users);
        }

        [HttpPost]
        public ActionResult IndexByFilter()
        {
            var fName = Request.Form["txtFName"]; 
            var lName = Request.Form["txtLName"];

            Expression<Func<Employee.Model.Employee, bool>> expression = null;
            if (fName == string.Empty && lName != string.Empty)
            {
                expression = x => x.LastName.Contains(lName);
            }
            else if (fName != string.Empty && lName == string.Empty)
            {
                expression = x => x.FirstName.Contains(fName);
            }
            else if (fName != string.Empty && lName != string.Empty)
            {
                expression = x => x.FirstName.Contains(fName) && x.LastName.Contains(lName);
            }

            //var user = this._iEmployeeService.QueryPage<Employee.Model.Employee,int>(u => u.FirstName.Contains(fName) || u.LastName.Contains(lName), 5, 1, u => u.EmployeeId);
            var user = this._iEmployeeService.Query<Employee.Model.Employee>(expression);

            return View("Index", user);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
