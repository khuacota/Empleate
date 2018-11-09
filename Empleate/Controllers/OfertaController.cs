﻿
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

        [HttpPost]
        public IActionResult Post([FromBody] OfertaTrabajoModel value)
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