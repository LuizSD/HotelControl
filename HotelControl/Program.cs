using System;
using System.Security;
using Microsoft.Owin.Hosting;

namespace HotelControl
{
    public class Program
    {
        static void Main()
        {
            //strat a lcoal serve, this makes the api independent of iis.
            const string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Server is now running...");
                Console.ReadLine();
            }
        }
    }
}