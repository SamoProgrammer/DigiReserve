using DigiReserve.Authentication;
using DigiReserve.Database;
using DigiReserve.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigiReserve.Logic
{
    public static class CheckTimes
    {
        public static bool RequestTime(DateTime time, List<ReserveTime> times)
        {
            return times.FirstOrDefault(x => x.ReservedTime == time) == null;
        }
        public static List<DateTime> AvaliableTimes(List<ReserveTime> times)
        {
            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            List<DateTime> avaliableTimes = new();
            var temp=time;
            int twoWeekAfter = time.Day + 14;
            while (time.Day <= twoWeekAfter)
            {
                if (time.Hour >= 9)
                    {
                        temp=temp.AddDays(1);
                        time = temp;
                    }
                while (time.Hour <= 10)
                {
                    
                    if (times.FirstOrDefault(x => x.ReservedTime == time) == null)
                    {
                        avaliableTimes.Add(time);
                        // System.Console.WriteLine(time);
                    }
                    time = time.AddMinutes(45);
                }

            }
            return avaliableTimes.ToList();
        }
    }
}
