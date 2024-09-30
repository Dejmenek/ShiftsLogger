using Microsoft.Extensions.Caching.Memory;
using ShiftsLogger.API.Data.Interfaces;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Data.Repositories;

public class CachingEmployeesRepository : IEmployeesRepository
{
    private readonly IEmployeesRepository _repository;
    private readonly IMemoryCache _cache;
    private const string EmployeesKey = "employees";

    public CachingEmployeesRepository(IEmployeesRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task AddEmployeeAsync(EmployeeCreateDTO employee)
    {
        await _repository.AddEmployeeAsync(employee);
    }

    public async Task<int> DeleteEmployeeAsync(int employeeId)
    {
        return await _repository.DeleteEmployeeAsync(employeeId);
    }

    public async Task<bool> EmployeeExists(int employeeId)
    {
        return await _repository.EmployeeExists(employeeId);
    }

    public async Task<List<EmployeeReadDTO>> GetEmployeesAsync()
    {
        return await _cache.GetOrCreateAsync(
            EmployeesKey,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                return await _repository.GetEmployeesAsync();
            });
    }

    public Task<List<ShiftReadDTO>?> GetEmployeeShiftsAsync(int employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateEmployeeAsync(int employeeId, EmployeeUpdateDTO employee)
    {
        return await _repository.UpdateEmployeeAsync(employeeId, employee);
    }
}
