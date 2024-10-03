using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ShiftsLogger.API.Configuration;
using ShiftsLogger.API.Data.Interfaces;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Data.Repositories;

public class CachingEmployeesRepository : IEmployeesRepository
{
    private readonly IEmployeesRepository _repository;
    private readonly IMemoryCache _cache;
    private readonly CachingSettings _cachingSettings;
    private const string EmployeesKey = "employees";

    public CachingEmployeesRepository(IOptions<CachingSettings> cachingSettings, IEmployeesRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
        _cachingSettings = cachingSettings.Value;
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
                entry.SetAbsoluteExpiration(_cachingSettings.EmployeeDetailsExpiration.ToTimeSpan());

                return await _repository.GetEmployeesAsync();
            });
    }

    public async Task<List<ShiftReadDTO>> GetEmployeeShiftsAsync(int employeeId)
    {
        string employeeShiftsKey = $"employeeShifts-{employeeId}";

        return await _cache.GetOrCreateAsync(
            employeeShiftsKey,
            async entry =>
            {
                entry.SetAbsoluteExpiration(_cachingSettings.EmployeeShiftsExpiration.ToTimeSpan());

                return await _repository.GetEmployeeShiftsAsync(employeeId);
            });
    }

    public async Task<int> UpdateEmployeeAsync(int employeeId, EmployeeUpdateDTO employee)
    {
        return await _repository.UpdateEmployeeAsync(employeeId, employee);
    }
}
