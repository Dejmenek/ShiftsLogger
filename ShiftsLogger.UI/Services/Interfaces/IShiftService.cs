using ShiftsLogger.UI.Models;

namespace ShiftsLogger.UI.Services.Interfaces;
public interface IShiftService
{
    Task AddShift();
    Task DeleteShift();
    Task UpdateShift();
    Task<List<ShiftReadDTO>> GetAllShifts();
}
