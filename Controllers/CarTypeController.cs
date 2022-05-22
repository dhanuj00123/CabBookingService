using API.Models;
using CabBookingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CarTypeController : ControllerBase
    {
        public ApplicationDbContext DbContext;
        public CarTypeController(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<CarType>> Get()
        {
            return await DbContext.CarTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> Get(int id)
        {
            try
            {
                var res = await DbContext.CarTypes.FindAsync(id);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpPost]
        [Route("AddCarType")]
        public async Task<CarType> AddCarType(CarType Model)
        {
            DbContext.CarTypes.Add(Model);
            await DbContext.SaveChangesAsync();
            return Model;
        }

        [HttpPut]
        [Route("UpdateCarType")]
        public ActionResult<CarType> UpdateCarType(CarType profile)
        {
            try
            {
                var res = DbContext.CarTypes.Update(profile);
                DbContext.SaveChanges();
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(profile);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpDelete]
        [Route("DeleteCarType")]
        public ActionResult<bool> RemoveCarTypeById(int id)
        {
            try
            {
                var res = DbContext.CarTypes.Where(a => a.Car_typeId == id).FirstOrDefault();
                DbContext.CarTypes.Remove(res);
                DbContext.SaveChanges();

                if (res == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

    }
}
