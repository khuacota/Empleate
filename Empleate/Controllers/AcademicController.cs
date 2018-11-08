using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empleate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Empleate.Repository;
using Empleate.Data;

namespace Empleate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        private AcademicHandler handler;

        public AcademicController(AppDbContext context)
        {
            this.handler = new AcademicHandler(context);
        }
        // GET: api/Academic
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Academic/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Academic
        [HttpPost]
        public IActionResult Post([FromBody] Academico value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                this.handler.Create(value);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        
        // PUT: api/Academic/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
