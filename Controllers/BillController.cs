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
    [ApiController]
    
    public class BillController : ControllerBase
    {
        public ApplicationDbContext DbContext;
        public BillController(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Bill>> Get()
        {
            return await DbContext.Bills.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> Get(int id)
        {
            try
            {
                var res = await DbContext.Bills.FindAsync(id);
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
        [Route("AddBill")]
        public async Task<Bill> AddBill( int booking_id, int car_t_id, float total)
        {
            Bill Model = new Bill();
            Model.Booking_Id = booking_id;
            Model.Car_type_Id = car_t_id;
            Model.TotalPrice = total;
            DbContext.Bills.Add(Model);
            await DbContext.SaveChangesAsync();
            return Model;
        }

        [HttpPut]
        [Route("UpdateBill")]
        public ActionResult<Booking> UpdateBill(int bill_id ,int booking_id, int car_t_id, float total)
        {
            try
            {
                Bill profile = new Bill();
                profile.Bill_Id = bill_id;
                profile.Booking_Id = booking_id;
                profile.Car_type_Id = car_t_id;
                profile.TotalPrice = total;
                DbContext.Bills.Add(profile);

                var res = DbContext.Bills.Update(profile);
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
        [Route("RemoveBill")]
        public ActionResult<bool> RemoveBillbyId(int id)
        {
            try
            {
                var res = DbContext.Bills.Where(a => a.Bill_Id == id).FirstOrDefault();
                DbContext.Bills.Remove(res);
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

