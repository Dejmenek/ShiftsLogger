namespace ShiftsLogger.API.Configuration;

public class CachingSettings
{
    public required Expiration EmployeeShiftsExpiration { get; set; }
    public required Expiration EmployeeDetailsExpiration { get; set; }

    public class Expiration
    {
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromDays(Days) + TimeSpan.FromHours(Hours) + TimeSpan.FromMinutes(Minutes);
        }
    }
}
