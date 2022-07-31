using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualCarHustler.Models;

namespace VirtualCarHustler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AllVehiclesController : ControllerBase
    {
        private DataContext _dataContext;
        public AllVehiclesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int count = 10)
        {
            var vehiclesToReturn = await _dataContext.Vehicles
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();

            return Ok(vehiclesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _dataContext.Vehicles.FirstOrDefaultAsync(elem => elem.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleModel vehToCreate)
        {
            await _dataContext.Vehicles.AddAsync(vehToCreate);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction("GetById", new {vehToCreate.Id}, vehToCreate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _dataContext.Vehicles.FirstOrDefaultAsync(elem => elem.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _dataContext.Vehicles.Remove(item);
            await _dataContext.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleModel taskUpdate)
        {
            var item = await _dataContext.Vehicles.FirstOrDefaultAsync(elem => elem.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            item.Description = taskUpdate.Description;
            item.Model = taskUpdate.Model;
            item.Mark = taskUpdate.Mark;
            item.ProductionDate = taskUpdate.ProductionDate;
            await _dataContext.SaveChangesAsync();

            return Ok(item);
        }

    }
}
