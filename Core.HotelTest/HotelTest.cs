using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Hotel;

namespace Core.HotelTest
{
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void CheckPriceForDate()
        {
            //creating a hotel
            var hotelLakewood = new Hotel.Hotel()
            {
                Name = "Lakewood",
                Rating = 3,
                WeekdayRegularCustomerPrice = 110,
                WeekdayRewardsCustomerPrice = 80,
                WeekendRegularCustomerPrice = 90,
                WeekendRewardsCustomerPrice = 80
            };

            //creating a customer
            var customer = new Customer() { Type = "Regular" };

            //creating a dates
            var dates = new List<DateTime>
            {
                DateTime.ParseExact("16Mar2009(mon)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("17Mar2009(tue)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("18Mar2009(wed)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
            };

            //geting number of the days in CallConvThiscall range of dates are in the weekend
            var countDaysOfWeekend = dates.Where(x => x.DayOfWeek == DayOfWeek.Sunday || x.DayOfWeek == DayOfWeek.Saturday).ToList().Count;

            //gets the price
            hotelLakewood.PriceForDate(dates, customer.Type , countDaysOfWeekend);

            //cheack if the price are right
            Assert.AreEqual(hotelLakewood.ReservePrice,330); 
        }
    }
}
