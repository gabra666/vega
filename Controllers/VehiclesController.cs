using Microsoft.AspNetCore.Mvc;
using VEGA.Models;

namespace VEGA.Controllers
{
    [RouteAttribute("/api/vehicles")]
    public class VehiclesController : Controller
    {
        [HttpPostAttribute()]
        public IActionResult CreateVehicle([FromBody]Vehicle vehicle)
        {
            return Ok(vehicle);
        }


    }
}