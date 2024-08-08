using ShiftsLogger.UI.Enums;
using ShiftsLogger.UI.Models;

namespace ShiftsLogger.UI.Services.Interfaces;
public interface IUserInteractionService
{
    string GetFirstName();
    string GetLastName();
    string GetDateTime();
    void GetUserInputToContinue();
    bool GetConfirmation(string title);
    Employee GetEmployee(List<Employee> employees);
    Shift GetShift(List<Shift> shifts);
    MenuOptions GetMenuOption();
    ManageShiftsOptions GetManageShiftsOptions();
    ManageEmployeesOptions GetManageEmployeesOptions();
}
