using DigiReserve.Authentication;
using DigiReserve.Database;
using DigiReserve.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigiReserve.Logic
{
    public static class ReservationService
    {
        public static bool checkAvaliablity(DateTime time, List<ReserveTime> times)
        {
            return times.FirstOrDefault(x => x.ReservedTime == time) == null;
        }
        public static List<DateTime> getAvaliableTimes(List<ReserveTime> times)
        {
            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            List<DateTime> avaliableTimes = new();
            var temp = time;
            DateTime twoWeekAfter = time.AddDays(14);
            while (time <= twoWeekAfter)
            {
                if (time.Hour > 17)
                {
                    temp = temp.AddDays(1);
                    time = temp;
                }
                while (time.Hour <= 17)
                {

                    if (times.FirstOrDefault(x => x.ReservedTime == time) == null)
                    {
                        avaliableTimes.Add(time);
                    }
                    time = time.AddMinutes(45);
                }

            }
            return avaliableTimes.ToList();
        }
    }
}
