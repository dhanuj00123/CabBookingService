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
    public class DriverController : ControllerBase
    {
        public ApplicationDbContext DbContext;
        public DriverController(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Driver>> Get()
        {
            return await DbContext.Drivers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> Get(int id)
        {
            try
            {
                var res = await DbContext.Drivers.FindAsync(id);
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
        [Route("AddDriver")]
        public async Task<Driver> AddDriver(Driver Model)
        {
            DbContext.Drivers.Add(Model);
            await DbContext.SaveChangesAsync();
            return Model;
        }

        [HttpPut]
        [Route("UpdateDriver")]
        public ActionResult<Driver> UpdateDriver(Driver profile)
        { 
            try
            {
                var res = DbContext.Drivers.Update(profile);
                DbContext.SaveChanges();
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(profile);
            }
            catch(Exception)
            {
                return BadRequest();         
             }
        
        }


        [HttpDelete]
        [Route("DeleteDriver")]
        public ActionResult<bool> RemoveDriverById(int id)
        {
            try
            {
                var res = DbContext.Drivers.Where(a => a.D_Id == id).FirstOrDefault();
                DbContext.Drivers.Remove(res);
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
