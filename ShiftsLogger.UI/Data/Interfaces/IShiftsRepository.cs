using ShiftsLogger.UI.Models;

namespace ShiftsLogger.UI.Data.Interfaces;
public interface IShiftsRepository
{
    Task AddShift(ShiftAddDTO shiftDto);
    Task DeleteShift(int shiftId);
    Task UpdateShift(int shiftId, ShiftUpdateDTO shiftDto);
    Task<List<Shift>?> GetAllShifts();
}
