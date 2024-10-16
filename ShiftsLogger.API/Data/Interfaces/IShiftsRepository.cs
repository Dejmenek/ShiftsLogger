﻿using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Data.Interfaces;

public interface IShiftsRepository
{
    public Task<List<ShiftReadDTO>> GetShiftsAsync();
    public Task<Shift?> GetShiftById(int shiftId);
    public Task AddShiftAsync(ShiftCreateDTO shift);
    public Task<int> UpdateShiftAsync(int shiftId, ShiftUpdateDTO shift);
    public Task<int> DeleteShiftAsync(int shiftId);
}
