namespace Employee.Interface
{
    public interface ITaskService : IBaseService
    {
        void DeleteByEmployeeID<T>(int employeeID);
    }
}
