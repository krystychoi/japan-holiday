using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Holiday
{
    private static HashSet<DateTime> GetHolidays(int year)
    {
        HashSet<DateTime> holidays = new HashSet<DateTime>();

        //Test Holiday
        //DateTime testHoliday = AdjustForWeekendHoliday(new DateTime(year, 6, 2).Date);
        //holidays.Add(testHoliday);

        //New Years Day
        DateTime newYearsDay = AdjustForWeekendHoliday(new DateTime(year, 1, 1).Date);
        holidays.Add(newYearsDay);

        //
        //Coming of Age Day -- 2nd Monday of January
        DateTime comingAgeDay = new DateTime(year, 1, 14);
        DayOfWeek dayOfWeek = comingAgeDay.DayOfWeek;
        while (dayOfWeek != DayOfWeek.Monday)
        {
            comingAgeDay = comingAgeDay.AddDays(-1);
            dayOfWeek = comingAgeDay.DayOfWeek;
        }
        holidays.Add(comingAgeDay.Date);

        //National Foundation Day -- February 11
        DateTime foundationDay = AdjustForWeekendHoliday(new DateTime(year, 2, 11).Date);
        holidays.Add(foundationDay);

        //Vernal Equinox Day
        string veday = Utility.GetSetting("VernalEquinox");
        DateTime vernalEquinoxDay = DateTime.Parse(veday);
        holidays.Add(vernalEquinoxDay.Date);

        //Showa Day -- April 29
        DateTime showaDay = AdjustForWeekendHoliday(new DateTime(year, 4, 29).Date);
        holidays.Add(showaDay);

        //Constitution Memorial Day -- May 3
        DateTime memorialDay = AdjustForWeekendHoliday(new DateTime(year, 5, 3).Date);
        holidays.Add(memorialDay);

        //Greenery Day -- May 4
        DateTime greeneryDay = AdjustForWeekendHoliday(new DateTime(year, 5, 4).Date);
        holidays.Add(greeneryDay);

        //Childrens Day -- May 5
        DateTime childrensDay = AdjustForWeekendHoliday(new DateTime(year, 5, 5).Date);
        holidays.Add(childrensDay);

        //Marine Day -- 3rd Monday of July
        DateTime marineDay = new DateTime(year, 7, 21);
        dayOfWeek = marineDay.DayOfWeek;
        while (dayOfWeek != DayOfWeek.Monday)
        {
            marineDay = marineDay.AddDays(-1);
            dayOfWeek = marineDay.DayOfWeek;
        }
        holidays.Add(marineDay.Date);

        //Mountain Day -- August 11
        DateTime mountainDay = AdjustForWeekendHoliday(new DateTime(year, 8, 11).Date);
        holidays.Add(mountainDay);

        //Respect for the Aged Day -- 3rd Monday of September
        DateTime respectAgedDay = new DateTime(year, 9, 21);
        dayOfWeek = respectAgedDay.DayOfWeek;
        while (dayOfWeek != DayOfWeek.Monday)
        {
            respectAgedDay = respectAgedDay.AddDays(-1);
            dayOfWeek = respectAgedDay.DayOfWeek;
        }
        holidays.Add(respectAgedDay.Date);

        //Autumnal Equinox Day
        string aeday = Utility.GetSetting("AutumnalEquinox");
        DateTime autumnalEquinoxDay = DateTime.Parse(aeday);
        holidays.Add(autumnalEquinoxDay);

        //Health-Sports Day -- 2nd Monday of October
        DateTime healthSportsDay = new DateTime(year, 10, 14);
        dayOfWeek = healthSportsDay.DayOfWeek;
        while (dayOfWeek != DayOfWeek.Monday)
        {
            healthSportsDay = healthSportsDay.AddDays(-1);
            dayOfWeek = healthSportsDay.DayOfWeek;
        }
        holidays.Add(healthSportsDay.Date);

        //Culture Day -- November 3
        DateTime cultureDay = AdjustForWeekendHoliday(new DateTime(year, 11, 3).Date);
        holidays.Add(cultureDay);

        //Labour Thanksgiving Day -- November 23
        DateTime labourTGDay = AdjustForWeekendHoliday(new DateTime(year, 11, 23).Date);
        holidays.Add(labourTGDay);

        //The Emperors Birthday -- December 23
        DateTime emperorsBirthday = AdjustForWeekendHoliday(new DateTime(year, 12, 23).Date);
        holidays.Add(emperorsBirthday);

        return holidays;
    }

    public static DateTime AdjustForWeekendHoliday(DateTime holiday)
    {
        if (holiday.DayOfWeek == DayOfWeek.Sunday)
        {
            return holiday.AddDays(1);
        }
        else
        {
            return holiday;
        }
    }

    public static bool IsHoliday(DateTime date)
    {
        //List<DateTime> HolidayList = GetHolidays(DateTime.Now.Year).ToList();
        return GetHolidays(DateTime.Now.Year).Contains(date);
    }

    public static bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    public static DateTime GetNextWorkingDay(DateTime date)
    {
        do
        {
            date = date.AddDays(1);
        } while (IsHoliday(date) || IsWeekend(date));
        return date;
    }

    //Added by Marvin
    public static bool IsWorkingDay(DateTime date)
    {
        bool bVal = true;

        if ((IsHoliday(date)) || (IsWeekend(date)))
        {
            bVal = false;
        }

        return bVal;
    }
}
