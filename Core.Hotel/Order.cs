using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Core.Hotel
{
    public class Order
    {
        public List<DateTime> Dates;
        public Customer Customer;

        //With a list of hotels and a souce file to extract others information, return a list of the cheapest hotle for 
        //each dates and type of customer
        public IEnumerable<string> GetCheapestHotel(List<Hotel> hotels, string source)
        {
            var fileResult = File.ReadAllLines(source).ToList();
            //extracts the file information
            //var fileResult = ExtractFile(File.OpenText(source)).ToList();
            //transforme the file information in a class
            var order = FormatOrder(fileResult);

            //gets the best hotel for each order
            return order.Select(t => GetCheapestHotel(t.Customer,t.Dates,hotels)).ToList();
            
        }

        //format the fiel information transforming in a order objetc.
        public static List<Order> FormatOrder(List<string> fileResult )
        {
            var order = new List<Order>();

            for (int x = 0; x < fileResult.Count; x++)
            {
                //gets the type of costumer, using : as a separator caracter, and transform in a customer objetc
                var resultNumber = fileResult[x].IndexOf(":", StringComparison.Ordinal);
                var resultSub = fileResult[x].Substring(0, resultNumber);
                var orderResult = new Order() {Customer = new Customer() {Type = resultSub}};

                //extratc the dates in the format was typing
                var textDates = fileResult[x].Substring(resultNumber, fileResult[x].Length - resultNumber).Replace(":","");
                var listDatesRaw = textDates.Split(',').ToList();
                var listDates = new List<DateTime>();

                for (int i = 0; i < listDatesRaw.Count; i++)
                {
                    //format tha day of tha date to user a native convert funtion
                    var startNumber = listDatesRaw[i].IndexOf("(", StringComparison.Ordinal); 
                    var finalNumber = listDatesRaw[i].IndexOf(")", StringComparison.Ordinal);
                    var textDay = listDatesRaw[i].Substring(startNumber, finalNumber - startNumber);
                    var validTextDay = textDay.Substring(0, 4);
                    var validFormatDate = listDatesRaw[i].Replace(textDay, validTextDay);
                    listDates.Add(DateTime.ParseExact(validFormatDate, "ddMMMyyyy(ddd)", CultureInfo.InvariantCulture));
                }

                //organzie the order objetc
                orderResult.Dates = listDates;
                order.Add(orderResult);
            }

            return order;
        }

        //gets file and make a IEnumerable<string>, to make easy to format
        public static IEnumerable<string> ExtractFile(TextReader file)
        {
            string order;
            while ((order = file.ReadLine()) != null)
            {
                yield return order;
            }
        }


        //Get the Cheapes hotel basead in a range fo a date 
        public string GetCheapestHotel(Customer customer, List<DateTime> dates, List<Hotel> hotels)
        {
            //gets a number foa days be a weekend
            var countDaysWeekend = IsWeekend(dates);

            //gets a price for the hotels in the range date.
            hotels.ForEach(x => x.PriceForDate(dates, customer.Type, countDaysWeekend));

            //gets the Cheapest, if the price are the same in one or more hotels, gets whith have a best rating
            var firstOrDefault = hotels.OrderBy(x => x.ReservePrice).ThenByDescending(x => x.Rating).FirstOrDefault();
            return firstOrDefault != null ? firstOrDefault.Name : null;
        }
        //chack if the day pas is a weekend
        private int IsWeekend(IEnumerable<DateTime> dates)
        {
            return dates.Where(x => x.DayOfWeek == DayOfWeek.Sunday || x.DayOfWeek == DayOfWeek.Saturday).ToList().Count;
        }
    }
}
