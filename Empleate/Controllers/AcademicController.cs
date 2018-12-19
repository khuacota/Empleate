using Empleate.Data;
using Empleate.Models;
using Empleate.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Empleate.Controllers
{
    [Route("academic")]
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

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Academic academic) {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            handler.Edit(academic);
            return Ok();
        }
        
    }
}
