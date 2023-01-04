namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        Employee EditEmployee(Employee employee);
        Employee DeleteEmployee(int id);
        Employee AddEmployee(Employee employee);
    }
}
