
using Empleate.Data;
using Empleate.Models;
using Empleate.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Empleate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OffersController : Controller
    {
        private OfertasHandler handler;

        public OffersController(AppDbContext context)
        {
            this.handler = new OfertasHandler(context);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OfferJobModel value)
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