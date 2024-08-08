using ShiftsLogger.UI.Models;

namespace ShiftsLogger.UI.Services.Interfaces;
public interface IEmployeeService
{
    Task AddEmployeeAsync();
    Task DeleteEmployeeAsync();
    Task UpdateEmployeeAsync();
    Task<List<EmployeeReadDTO>> GetAllEmployeesAsync();
    Task<List<ShiftReadDTO>?> GetEmployeeShiftsAsync();
}
