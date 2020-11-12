using Employee.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Interface.IService
{
    public interface IEmployeeTask: IBaseService
    {
        void Show();
        /// <summary>
        /// 根据EmployeeID查询相关的Task
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        IEnumerable<EmployeeTask> GetEmployeeTaskList(int EmployeeID);
    }
}
