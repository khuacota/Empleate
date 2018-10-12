using Empleate.Data;
using Empleate.Models;
using Empleate.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Controllers
{
    [Route("profesiones")]
    [ApiController]
    public class ProfesionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfesionesController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult GetProfesionesByDescription(string description)
        {
            using (var repository = new ProfesionHandler(this._context))
            {
                var profesion = repository.FindProfesionByDescription(description);
                if (profesion == null)
                {
                    return NotFound();
                }
                return Ok(profesion);
            }
        }

        // GET: api/Profesiones
        [HttpGet]
        public IEnumerable<Profesion> GetProfesiones()
        {
            return _context.Profesiones;
        }

        [HttpGet("{description}")]
        public IActionResult EmpleadosByProfesion(string description)
        {
            var Empleados = new List<Empleado>();
            using (var repository = new ProfesionHandler(this._context))
            {
                var profesion = repository.FindProfesionByDescription(description);
                if (profesion == null)
                {
                    return NotFound();
                }
                return Ok(profesion.Empleados);
            }
        }

        // GET: api/Profesionales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profesion = await _context.Profesiones.FindAsync(id);

            if (profesion == null)
            {
                return NotFound();
            }

            return Ok(profesion);
        }

        // PUT: api/Profesionales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesion([FromRoute] int id, [FromBody] Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesion.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Profesionales
        [HttpPost]
        public async Task<IActionResult> PostProfesion([FromBody] Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Profesiones.Add(profesion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesion", new { id = profesion.Id }, profesion);
        }

        // DELETE: api/Profesionales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profesion = await _context.Profesiones.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }

            _context.Profesiones.Remove(profesion);
            await _context.SaveChangesAsync();

            return Ok(profesion);
        }

        private bool ProfesionExists(int id)
        {
            return _context.Profesiones.Any(e => e.Id == id);
        }
    }
}