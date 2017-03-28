using System.Collections.Generic;
using Core.Hotel;
using HotelControl.Repository.Contracts;


namespace HotelControl.Repository
{
    class HotelRepository : IHotelRepository
    {

        public List<string> GetCheapestHotel(string fileName = "orders.txt") 
        {
            //Gets the cheapest hotle basead ina a file passed 
            var listHotels = GetsHotels();

            var hotelControl = new Order();
           
            return (List<string>) hotelControl.GetCheapestHotel(listHotels, @"../../../" + fileName);
        }
        public List<Hotel> GetsHotels() 
        {
            //creating a list of hotel
            var hotelLakewood = new Hotel()
            {
                Name = "Lakewood",
                Rating = 3,
                WeekdayRegularCustomerPrice = 110,
                WeekdayRewardsCustomerPrice = 80,
                WeekendRegularCustomerPrice = 90,
                WeekendRewardsCustomerPrice = 80
            };

            var hotelBridgewood = new Hotel()
            {
                Name = "Bridgewood",
                Rating = 4,
                WeekdayRegularCustomerPrice = 160,
                WeekdayRewardsCustomerPrice = 110,
                WeekendRegularCustomerPrice = 60,
                WeekendRewardsCustomerPrice = 50
            };

            var hotelRidgewood = new Hotel()
            {
                Name = "Ridgewood",
                Rating = 5,
                WeekdayRegularCustomerPrice = 220,
                WeekdayRewardsCustomerPrice = 100,
                WeekendRegularCustomerPrice = 150,
                WeekendRewardsCustomerPrice = 40

            };

            return new List<Hotel> { hotelBridgewood, hotelLakewood, hotelRidgewood };
        }
    }
}
