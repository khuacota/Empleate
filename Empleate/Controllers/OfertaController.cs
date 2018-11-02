
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empleate.Repository;
using Empleate.Data;
using Empleate.Models;

namespace Empleate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfertaController : Controller
    {
        private AcademicHandler handler;

        public OfertaController(AppDbContext context)
        {
            this.handler = new AcademicHandler(context);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Academico value)
        {
            try
            {
                this.handler.Create(value);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }
    }
}