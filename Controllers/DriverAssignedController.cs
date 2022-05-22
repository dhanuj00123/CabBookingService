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
    public class DriverAssignedController : ControllerBase
    {
        public ApplicationDbContext DbContext;
        public DriverAssignedController(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Driver_Assigned>> Get()
        {
            return await DbContext.DriverAssigned.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver_Assigned>> Get(int id)
        {
            try
            {
                var res = await DbContext.DriverAssigned.FindAsync(id);
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
        [Route("AddDriverAssigned")]
        public async Task<Driver_Assigned> AddDriverAssigned(int D_Id,int B_id, int c_id)
        {
            Driver_Assigned model = new Driver_Assigned();
            model.D_Id = D_Id;
            model.Booking_Id = B_id;
            model.Car_Id = c_id;
            DbContext.DriverAssigned.Add(model);
            await DbContext.SaveChangesAsync();
            return model;
        }

        [HttpPut]
        [Route("UpdateDriverAssigned")]
        public ActionResult<Driver_Assigned> UpdateDriverAssigned(int da_id,int D_Id, int B_id, int c_id)
        {
            try
            {
                Driver_Assigned profile = new Driver_Assigned();
                profile.DA_Id = da_id;
                profile.D_Id = D_Id;
                profile.Booking_Id= B_id;
                profile.Car_Id = c_id;
                var res = DbContext.DriverAssigned.Update(profile);
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
        [Route("RemoveDriverAssigned")]
        public ActionResult<bool> RemoveDriverAssignedId(int id)
        {
            try
            {
                var res = DbContext.DriverAssigned.Where(a => a.DA_Id == id).FirstOrDefault();
                DbContext.DriverAssigned.Remove(res);
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
