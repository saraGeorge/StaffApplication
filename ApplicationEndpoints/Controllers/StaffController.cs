using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApplicationEndpoints.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private ApplicationDBContext.StaffDBContext _context;

        public StaffController(ApplicationDBContext.StaffDBContext context)
        {

            _context = context;
            if (!_context.Staffs.Any())
            {
                _context.Staffs.Add(new Staff
                {
                    id = 1,
                    firstname = "sara",
                    lastname = "tom",
                    emailId = "saratom@gmail.com",
                    role = "teaching"
                });

                _context.Staffs.Add(new Staff
                {
                    id = 2,
                    firstname = "maria",
                    lastname = "james",
                    emailId = "mariajames@gmail.com",
                    role = "admin"
                });

                _context.Staffs.Add(new Staff
                {
                    id = 3,
                    firstname = "serin",
                    lastname = "jones",
                    emailId = "serinjones@gmail.com",
                    role = "hr"
                });

                _context.SaveChanges();
            }


        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<Staff> Get()
        {

            // fetch files from csv file
            try
            {
                return Ok(_context.Staffs);

            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Staff staffById = _context.Staffs.Single(staff => staff.id == id);
                return Ok(staffById);

            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Staff staff)
        {
            try
            {
                _context.Staffs.Add(staff);
                _context.SaveChanges();
                return CreatedAtRoute("Get", new { id = staff.id }, staff);

            }
            catch
            {
                return Conflict();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Staff staff)
        {
            try
            {
                Staff staffById = _context.Staffs.Single(staff => staff.id == id);
                if(staffById == null)
                {
                    return NotFound();
                }
               
                    staffById.id = staff.id;
                    staffById.lastname = staff.lastname;
                    staffById.firstname = staff.firstname;
                    staffById.emailId = staff.emailId;
                    staffById.role = staff.role;

                    _context.Staffs.Update(staffById);
                    _context.SaveChanges();
                    return new NoContentResult();
                
                

            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Staff staffById = _context.Staffs.Single(staff => staff.id == id);
                if (staffById == null)
                {
                    return NotFound();
                }
                
                _context.Staffs.Remove(staffById);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {
                return NotFound();
            }
        }
    }
}
