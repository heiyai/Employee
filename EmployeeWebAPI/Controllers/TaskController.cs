﻿using Employee.Interface;
using EmployeeWebAPI.Utility.Filter;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

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
        
        [HttpGet]
        [Route("getbyemployeeid/{id:int}")]
        public IEnumerable<T> GetByEmployeeID(int id)
        {
            return this._iTaskService.Query<T>(x => x.EmployeeId == id);
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var task = this._iTaskService.Find<T>(id);
            if (task == null)
                return app.Tag.Failed;
            return Newtonsoft.Json.JsonConvert.SerializeObject(task);
        }

        
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

        
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            _iTaskService.Delete<T>(id);
            return response;
        }

        [Route("delbyemployeeid/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteByEmployee(int id)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            _iTaskService.DeleteByEmployeeID<T>(id);
            return response;
        }
    }
}
