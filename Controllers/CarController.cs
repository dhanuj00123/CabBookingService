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
    public class CarController : ControllerBase
    {
        
       
            public ApplicationDbContext DbContext;
            public CarController(ApplicationDbContext applicationDbContext)
            {
                DbContext = applicationDbContext;
            }

            [HttpGet]
            public async Task<IEnumerable<Car>> Get()
            {
                return await DbContext.Cars.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Car>> Get(int id)
            {
                try
                {
                    var res = await DbContext.Cars.FindAsync(id);
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
            [Route("AddCar")]
            public async Task<Car> Addcar(int car_t_id,  string carno,string carmo ,string nofseats ,string fueltype)
            {
                Car Model = new Car();
                Model.Car_type_Id = car_t_id;
                Model.CarNumber = carno;
                Model.CarModel = carmo;
                Model.NoOfSeat = nofseats;
                Model.FuelType = fueltype;
                DbContext.Cars.Add(Model);
                await DbContext.SaveChangesAsync();
                return Model;
            }

            [HttpPut]
            [Route("UpdateCar")]
            public ActionResult<Car> Updatecar(int car_id,int car_t_id, string carno, string carmo, string nofseats, string fueltype)
            {
                try
                {
                    Car profile = new Car();
                    profile.Car_Id = car_id;
                    profile.Car_type_Id = car_t_id;
                    profile.CarNumber = carno;
                    profile.CarModel = carmo;
                    profile.NoOfSeat = nofseats;
                    profile.FuelType = fueltype;
                    var res = DbContext.Cars.Update(profile);
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
            [Route("DeleteCar")]
            public ActionResult<bool> RemovecarById(int id)
            {
                try
                {
                    var res = DbContext.Cars.Where(a => a.Car_Id == id).FirstOrDefault();
                    DbContext.Cars.Remove(res);
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
