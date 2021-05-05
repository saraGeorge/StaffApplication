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
       
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<Staff> Get()
        {

            // fetch files from csv file
            try
            {
                return Ok(StaffDetailsFromFile.getStaffDetailsFromFile());

            }
            catch (Exception exception)
            {
                return NotFound();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
