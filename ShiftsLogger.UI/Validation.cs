﻿using Spectre.Console;
using System.Globalization;

namespace ShiftsLogger.UI;
public static class Validation
{
    public static ValidationResult IsValidString(string input)
    {
        if (input.Trim().Length != 0)
        {
            return ValidationResult.Success();
        }
        else
        {
            return ValidationResult.Error("Your input must not be empty!");
        }
    }

    public static bool IsChronologicalOrder(DateTime startDate, DateTime endDate)
    {
        int result = DateTime.Compare(startDate, endDate);

        if (result < 0 || result == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static ValidationResult IsValidDateTimeFormat(string? userDate)
    {
        if (DateTime.TryParseExact(userDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return ValidationResult.Success();
        }
        else
        {
            return ValidationResult.Error("[red]You must enter a valid date time format: yyyy-MM-dd HH:mm[/]");
        }
    }
}
