using CRUDAppUsingADO.Models;

namespace CRUDAppUsingADO
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployee();
        void AddEmployee(Employee employee);
        Employee GetEmployeeById(int? Id);

        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int? id);
    }
}
