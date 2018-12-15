using Empleate.Data;
using Empleate.Models;
using Empleate.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Empleate.Controllers
{
    [Route("Oferta")]
    [ApiController]
    public class OffersController : Controller
    {
        private OffersHandler handler;

        public OffersController(AppDbContext context)
        {
            this.handler = new OffersHandler(context);
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

        [HttpGet("recientes")]
        public IActionResult GetRecentOffers() {
            IList<JobOffer> recentOffers = this.handler.GetRecentOffers();
            return Ok(recentOffers);
        } 
    }
}