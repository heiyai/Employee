using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Service;
using Employee.Interface;
using Employee.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeWebAPI.Controllers
{
    using T = Employee.Model.Task;

    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _iTaskService = null;
        public TaskController(ITaskService taskService)
        {
            this._iTaskService = taskService;
        }
        // GET: api/<TaskController>
        [HttpGet]
        [Route("getbyemployeeid/{id:int}")]
        public IEnumerable<T> GetByEmployeeID(int id)
        {
            return this._iTaskService.Query<T>(x => x.EmployeeId == id); 
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var task = this._iTaskService.Find<T>(id);
            if (task == null)
                return app.Tag.Failed;
            return Newtonsoft.Json.JsonConvert.SerializeObject(task);
        }

        // POST api/<TaskController>
        [HttpPost]
        public HttpResponseMessage Post(string value)
        {
            var response = new HttpResponseMessage();
            T task = JsonConvert.DeserializeObject<T>(value);
            var entity = _iTaskService.Insert<T>(task);
            if (entity == null || entity.EmployeeId <= 0)
                response.StatusCode = HttpStatusCode.BadRequest;
            else
                response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        // PUT api/<TaskController>/5
        [HttpPut]
        public HttpResponseMessage Put(int id, string value)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            T task = JsonConvert.DeserializeObject<T>(value);
            task.TaskId = id;
            _iTaskService.Update<T>(task);
            return response;
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;

            try
            {
                _iTaskService.Delete<T>(id);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            return response;
        }

        [Route("delbyemployeeid/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteByEmployee(int id)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;

            try
            {
                _iTaskService.DeleteByEmployeeID<T>(id);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            return response;
        }
    }
}
