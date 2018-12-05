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

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = this.handler.GetOne(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST: api/Academic
        [HttpPost]
        public IActionResult Post([FromBody] Academic value)
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
        
    }
}
