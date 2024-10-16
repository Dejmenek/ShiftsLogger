﻿using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Data.Interfaces;

public interface IEmployeesRepository
{
    public Task<List<EmployeeReadDTO>> GetEmployeesAsync();
    public Task<List<ShiftReadDTO>> GetEmployeeShiftsAsync(int employeeId);
    public Task<Employee?> GetEmployeeById(int employeeId);
    public Task AddEmployeeAsync(EmployeeCreateDTO employee);
    public Task<int> UpdateEmployeeAsync(int employeeId, EmployeeUpdateDTO employee);
    public Task<int> DeleteEmployeeAsync(int employeeId);
    public Task<bool> EmployeeExists(int employeeId);
}
