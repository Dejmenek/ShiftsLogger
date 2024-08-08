using ShiftsLogger.UI.Models;
using ShiftsLogger.UI.Services.Interfaces;

namespace ShiftsLogger.UI.Controllers;
public class EmployeesController
{
    private readonly IEmployeeService _employeesService;

    public EmployeesController(IEmployeeService employeesService)
    {
        _employeesService = employeesService;
    }

    public async Task AddEmployeeAsync()
    {
        await _employeesService.AddEmployeeAsync();
    }

    public async Task RemoveEmployeeAsync()
    {
        await _employeesService.DeleteEmployeeAsync();
    }

    public async Task UpdateEmployeeAsync()
    {
        await _employeesService.UpdateEmployeeAsync();
    }

    public async Task<List<EmployeeReadDTO>?> GetEmployeesAsync()
    {
        return await _employeesService.GetAllEmployeesAsync();
    }

    public async Task<List<ShiftReadDTO>?> GetEmployeeShifts()
    {
        return await _employeesService.GetEmployeeShiftsAsync();
    }
}
