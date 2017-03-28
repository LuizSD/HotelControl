using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Hotel
{
    public class Hotel
    {
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public decimal WeekdayRewardsCustomerPrice { get; set; }
        public decimal WeekendRewardsCustomerPrice { get; set; }
        public decimal WeekdayRegularCustomerPrice { get; set; }
        public decimal WeekendRegularCustomerPrice { get; set; }
        public decimal ReservePrice { get; set; }
        public string City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        //Return the for for a hotel, base on date and type of costumer
        public void PriceForDate(List<DateTime> dates, string customerType, int countDaysWeekend)
        {
            //make a diferent count depends a type of costumer, and number of days that be a weekend
            ReservePrice  = customerType.ToUpper().Equals("REWARD")
                ? (WeekdayRewardsCustomerPrice*(dates.Count() - countDaysWeekend)) +
                  (WeekendRewardsCustomerPrice*countDaysWeekend)
                : (WeekdayRegularCustomerPrice*(dates.Count() - countDaysWeekend)) +
                  (WeekendRegularCustomerPrice*countDaysWeekend);
        }
    }
}

