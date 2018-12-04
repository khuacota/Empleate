
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
        private OfertasHandler handler;

        public OfertaController(AppDbContext context)
        {
            this.handler = new OfertasHandler(context);
        }

        [HttpGet("search")]
        public IActionResult GetJobsByCompany([FromQuery] string[] searchWord)
        {

            var results = this.handler.filterByCompany(searchWord);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetJob([FromRoute] int id)
        {

            try
            {
                var results = this.handler.GetOne(id);
                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] JobOfferModel value)
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

        [HttpPost("postulate")]
        public IActionResult Postulate([FromBody] Postulation value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                this.handler.Postulate(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}