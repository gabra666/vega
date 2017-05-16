using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VEGA.Controllers.Resources;
using VEGA.Models;
using VEGA.Persistence;

namespace VEGA.Controllers
{
    [RouteAttribute("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;

        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPostAttribute()]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
        [HttpPutAttribute("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await context.Vehicles.FindAsync(id);
            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }


    }
}