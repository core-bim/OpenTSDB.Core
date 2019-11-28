using System;
using System.Collections.Generic;
using System.Linq;
namespace OpenTSDB.Core.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a DateTime to a Unix Timestamp
        /// </summary>
        /// <param name="target">This DateTime</param>
        /// <returns></returns>
        public static double ToUnixTimestamp(this DateTime target)
        {
            DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Math.Floor((target - d).TotalSeconds);
        }

        /// <summary>
        /// Converts a Unix Timestamp in to a DateTime
        /// </summary>
        /// <param name="unixTime">This Unix Timestamp</param>
        /// <returns></returns>
        public static DateTime FromUnixTimestamp(this double unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTime);
        }

        /// <summary>
        /// Gets the value of the End of the day (23:59)
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static DateTime ToDayEnd(this DateTime target)
        {
            DateTime dateTime = target.Date;
            dateTime = dateTime.AddDays(1.0);
            return dateTime.AddMilliseconds(-1.0);
        }

        /// <summary>
        /// Gets the First Date of the week for the specified date
        /// </summary>
        /// <param name="dt">this DateTime</param>
        /// <param name="startOfWeek">The Start Day of the Week (ie, Sunday/Monday)</param>
        /// <returns>The First Date of the week</returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int num = dt.DayOfWeek - startOfWeek;
            if (num < 0)
            {
                num += 7;
            }
            return dt.AddDays((double)(-1 * num)).Date;
        }

        /// <summary>
        /// Returns all the days of a month.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> DaysOfMonth(int year, int month)
        {
            return from day in Enumerable.Range(0, DateTime.DaysInMonth(year, month))
                   select new DateTime(year, month, day + 1);
        }

        /// <summary>
        /// Determines the Nth instance of a Date's DayOfWeek in a month
        /// </summary>
        /// <returns></returns>
        /// <example>11/29/2011 would return 5, because it is the 5th Tuesday of each month</example>
        public static int WeekDayInstanceOfMonth(this DateTime dateTime)
        {
            int y = 0;
            return (from date in DateTimeExtensions.DaysOfMonth(dateTime.Year, dateTime.Month)
                    where dateTime.DayOfWeek.Equals(date.DayOfWeek)
                    select date into x
                    select new
                    {
                        n = ++y,
                        date = x
                    } into x
                    where x.date.Equals(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day))
                    select x.n).FirstOrDefault();
        }

        /// <summary>
        /// Gets the total days in a month
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static int TotalDaysInMonth(this DateTime dateTime)
        {
            return DateTimeExtensions.DaysOfMonth(dateTime.Year, dateTime.Month).Count();
        }

        /// <summary>
        /// Takes any date and returns it's value as an Unspecified DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeUnspecified(this DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
            {
                return date;
            }
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Unspecified);
        }

        /// <summary>
        /// Trims the milliseconds off of a datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime TrimMilliseconds(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
        }
    }

}