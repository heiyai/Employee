using System;
using System.Collections.Generic;

namespace Employee.Interface
{
    public interface IEmployeeService : IBaseService
    {
        /// <summary>
        /// 查询并缓存全部的类别数据
        /// 类别数据一般是不变化的
        /// </summary>
        /// <returns></returns>
        List<Employee.Model.Employee> CacheAllEmployee();
    }
}
