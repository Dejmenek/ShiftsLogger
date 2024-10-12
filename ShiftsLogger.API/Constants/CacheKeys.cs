namespace ShiftsLogger.API.Constants;

public static class CacheKeys
{
    public static class Employees
    {
        public const string List = "employees";
        public const string ShiftsTemplate = "employeeShifts-{0}";

        public static string Shifts(int employeId) => string.Format(ShiftsTemplate, employeId);
    }
}
