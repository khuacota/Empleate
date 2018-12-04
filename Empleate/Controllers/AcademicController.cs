using Empleate.Data;
using Empleate.Models;
using Empleate.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
