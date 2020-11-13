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
            var users = this._iEmployeeService.Set<Employee.Model.Employee>();
            return View(users);
        }

        [HttpPost]
        public ActionResult IndexByFilter()
        {
            var fName = Request.Form[app.Tag.FirstName];
            var lName = Request.Form[app.Tag.LastName];

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

            return View(nameof(Index), user);
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
                var lastName = collection[app.Tag.LastName];
                var firstName = collection[app.Tag.FirstName];

                Employee.Model.Employee emp = new Employee.Model.Employee()
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                var entity = this._iEmployeeService.Insert<Employee.Model.Employee>(emp);
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
            var entity = _iEmployeeService.Find<Employee.Model.Employee>(id);
            return View(entity);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Employee.Model.Employee emp = new Employee.Model.Employee()
                {
                    EmployeeId = int.Parse(collection[app.Tag.EmployeeId]),
                    FirstName = collection[app.Tag.LastName],
                    LastName = collection[app.Tag.FirstName],
                    HiredDate = DateTime.Parse(collection[app.Tag.HiredDate])
                };

                this._iEmployeeService.Update<Employee.Model.Employee>(emp);
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
            var entity = _iEmployeeService.Find<Employee.Model.Employee>(id);
            return View(entity);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _iEmployeeService.Delete<Employee.Model.Employee>(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
