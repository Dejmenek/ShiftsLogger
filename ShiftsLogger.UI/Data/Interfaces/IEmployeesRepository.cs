using ShiftsLogger.UI.Models;

namespace ShiftsLogger.UI.Data.Interfaces;
public interface IEmployeesRepository
{
    Task AddEmployeeAsync(EmployeeDTO employeeDto);
    Task DeleteEmployeeAsync(int employeeId);
    Task UpdateEmployeeAsync(int employeeId, EmployeeDTO employeeDto);
    Task<List<Employee>?> GetAllEmployeesAsync();
    Task<List<Shift>?> GetEmployeeShiftsAsync(int employeeId);
}
