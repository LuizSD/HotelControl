using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Hotel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.HotelTest
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void CheckCheapestHotelFile()
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

            var hotelBridgewood = new Hotel.Hotel()
            {
                Name = "Bridgewood",
                Rating = 4,
                WeekdayRegularCustomerPrice = 160,
                WeekdayRewardsCustomerPrice = 110,
                WeekendRegularCustomerPrice = 60,
                WeekendRewardsCustomerPrice = 50
            };

            var hotelRidgewood = new Hotel.Hotel()
            {
                Name = "Ridgewood",
                Rating = 5,
                WeekdayRegularCustomerPrice = 220,
                WeekdayRewardsCustomerPrice = 100,
                WeekendRegularCustomerPrice = 150,
                WeekendRewardsCustomerPrice = 40

            };

            var listHotels = new List<Hotel.Hotel> { hotelBridgewood, hotelLakewood, hotelRidgewood };

            //Get the cheapest hotel basead in a file
            var order = new Order();
            var result = order.GetCheapestHotel(listHotels, @"../../../orders.txt");

            //check if the hotel is a valid hotel
            Assert.IsTrue(result.Contains("Lakewood") || result.Contains("Bridgewood") || result.Contains("Ridgewood"));

        }

        [TestMethod]
        public void CheckCheapestHotelLakewood()
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

            var hotelBridgewood = new Hotel.Hotel()
            {
                Name = "Bridgewood",
                Rating = 4,
                WeekdayRegularCustomerPrice = 160,
                WeekdayRewardsCustomerPrice = 110,
                WeekendRegularCustomerPrice = 60,
                WeekendRewardsCustomerPrice = 50
            };

            var hotelRidgewood = new Hotel.Hotel()
            {
                Name = "Ridgewood",
                Rating = 5,
                WeekdayRegularCustomerPrice = 220,
                WeekdayRewardsCustomerPrice = 100,
                WeekendRegularCustomerPrice = 150,
                WeekendRewardsCustomerPrice = 40

            };

            var listHotels = new List<Hotel.Hotel> { hotelBridgewood, hotelLakewood, hotelRidgewood };

            //creating a customer
            var customer = new Customer() { Type = "Regular" };

            //creating the dates
            var dates = new List<DateTime>
            {
                DateTime.ParseExact("16Mar2009(mon)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("17Mar2009(tue)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("18Mar2009(wed)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
            };

            //Get the cheapest hotel
            var hotelControl = new Order();

            var cheaperHotel = hotelControl.GetCheapestHotel(customer, dates, listHotels);

            //check if the hotel is the rigth hotel
            Assert.AreEqual(cheaperHotel, "Lakewood");
        }

        [TestMethod]
        public void CheckCheapestHotelBridgewood()
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

            var hotelBridgewood = new Hotel.Hotel()
            {
                Name = "Bridgewood",
                Rating = 4,
                WeekdayRegularCustomerPrice = 160,
                WeekdayRewardsCustomerPrice = 110,
                WeekendRegularCustomerPrice = 60,
                WeekendRewardsCustomerPrice = 50
            };

            var hotelRidgewood = new Hotel.Hotel()
            {
                Name = "Ridgewood",
                Rating = 5,
                WeekdayRegularCustomerPrice = 220,
                WeekdayRewardsCustomerPrice = 100,
                WeekendRegularCustomerPrice = 150,
                WeekendRewardsCustomerPrice = 40
               
            };

            var listHotels = new List<Hotel.Hotel> {hotelBridgewood, hotelLakewood, hotelRidgewood};

            //creating a customer
            var customer = new Customer() { Type = "Regular" };

            //creating the dates
            var dates = new List<DateTime>
            {
                DateTime.ParseExact("20Mar2009(fri)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("21Mar2009(sat)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("22Mar2009(sun)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
            };

            //Get the cheapest hotel
            var hotelControl = new Order();

            var cheaperHotel = hotelControl.GetCheapestHotel(customer, dates, listHotels);

            //check if the hotel is the rigth hotel
            Assert.AreEqual(cheaperHotel, "Bridgewood");
        }

        [TestMethod]
        public void CheckCheapestHotelRidgewood()
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

            var hotelBridgewood = new Hotel.Hotel()
            {
                Name = "Bridgewood",
                Rating = 4,
                WeekdayRegularCustomerPrice = 160,
                WeekdayRewardsCustomerPrice = 110,
                WeekendRegularCustomerPrice = 60,
                WeekendRewardsCustomerPrice = 50
            };

            var hotelRidgewood = new Hotel.Hotel()
            {
                Name = "Ridgewood",
                Rating = 5,
                WeekdayRegularCustomerPrice = 220,
                WeekdayRewardsCustomerPrice = 100,
                WeekendRegularCustomerPrice = 150,
                WeekendRewardsCustomerPrice = 40

            };

            var listHotels = new List<Hotel.Hotel> { hotelBridgewood, hotelLakewood, hotelRidgewood };

            //creating a customer
            var customer = new Customer() { Type = "Reward" };

            //creating the dates
            var dates = new List<DateTime>
            {
                DateTime.ParseExact("26Mar2009(thu)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("27Mar2009(fri)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
                DateTime.ParseExact("28Mar2009(sat)", "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture),
            };

            //Get the cheapest hotel
            var hotelControl = new Order();

            var cheaperHotel = hotelControl.GetCheapestHotel(customer, dates, listHotels);

            //check if the hotel is the rigth hotel
            Assert.AreEqual(cheaperHotel, "Ridgewood");
        }

        
    }
}
