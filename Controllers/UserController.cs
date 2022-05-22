using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;
using CabBookingSystem.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        public ApplicationDbContext DbContext;
        public UserController(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }

       

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await DbContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                var res = await DbContext.Users.FindAsync(id);
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
        [Route("AddUsers")]
        public async Task<User> AddUsers( User Model)
        {
            DbContext.Users.Add(Model);
            await DbContext.SaveChangesAsync();
            return Model;
        }


        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<User>UpdateUser( User profile)
        {

            try
            {
                var res = DbContext.Users.Update(profile);
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
        [Route("DeleteUser")]
        public ActionResult<bool> RemoveUserById(int id)
        {

            try
            {
                var res = DbContext.Users.Where(a => a.U_Id == id).FirstOrDefault();
                DbContext.Users.Remove(res);
                DbContext.SaveChanges();

                if (res == null)
                {
                    return NotFound();
                }
                return Ok(true);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
    }



}
