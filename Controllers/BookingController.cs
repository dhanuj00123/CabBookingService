using API.Models;
using CabBookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
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
    [ApiController]
    
    public class BookingController : ControllerBase
    {
        public ApplicationDbContext DbContext;
        public BookingController(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Booking>> Get()
        {
            return await DbContext.Bookings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> Get(int id)
        {
            try
            {
                var res = await DbContext.Bookings.FindAsync(id);
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
        [Route("AddBooking")]
        public async Task<Booking> AddBooking(int u_id,int c_id ,string pickup, string drop, string dist ,DateTime pick_date, DateTime pick_time)
        {
            Booking Model = new Booking();
            Model.U_Id = u_id;
            Model.Car_Id = c_id;
            Model.Pickup = pickup;
            Model.Drop=drop;
            Model.Distance = dist;
            Model.PickDate = pick_date;
            Model.PickTime = pick_time;
            DbContext.Bookings.Add(Model);
            await DbContext.SaveChangesAsync();
            return Model;
        }

        [HttpPut]
        [Route("UpdateBookings")]
        public ActionResult<Booking> UpdateBookings(int booking_id ,int u_id, int c_id, string pickup, string drop, string dist, DateTime pick_date, DateTime pick_time)
        {
            try
            {
                Booking profile = new Booking();
                profile.Booking_Id=booking_id;
                profile.U_Id = u_id;
                profile.Car_Id = c_id;
                profile.Pickup = pickup;
                profile.Drop = drop;
                profile.Distance = dist;
                profile.PickDate = pick_date;
                profile.PickTime = pick_time;
                var res = DbContext.Bookings.Update(profile);
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
        [Route("RemoveBookings")]
        public ActionResult<bool> RemoveBookingsbyId(int id)
        {
            try
            {
                var res = DbContext.Bookings.Where(a => a.Booking_Id == id).FirstOrDefault();
                DbContext.Bookings.Remove(res);
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
