using System.Web.Http;
using HotelControl.Repository;

namespace HotelControl.Controllers
{
    [RoutePrefix("api/hotels")]
    public class HotelController : ApiController
    {
        private readonly HotelRepository _db = new HotelRepository();

        //gets all hotels
        [Route("all")]
        public IHttpActionResult GetsHotels()
        {
            
            var result = _db.GetsHotels();
            return Ok(result);
        }

        //gets a cheapest beased in a file name
        [Route("cheapest/filename/{fileName}")]
        public IHttpActionResult GetCheapestHotel(string fileName)
        {
            var result = _db.GetCheapestHotel(fileName);
            return Ok(result);
        }
        //gets a cheapest beased in a predetermined file
        [Route("cheapest")]
        public IHttpActionResult GetCheapestHotel()
        {
            var result = _db.GetCheapestHotel();
            return Ok(result);
        }
    }
}
