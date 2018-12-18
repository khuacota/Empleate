using Empleate.Data;
using Empleate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleate.Controllers
{
    [Route("empresas")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        public IEnumerable<Company> GetEmpresas()
        {
            return _context.Companies;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa = await _context.Companies.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpGet("user/{id}")]
        public  IActionResult GetCompanyByUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa =  _context.Companies.Where(c =>c.IdUser == id ).ToList();

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa([FromRoute] int id, [FromBody] Company empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
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

        [HttpPost]
        public async Task<IActionResult> PostEmpresa([FromBody] Company empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Companies.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.Id }, empresa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa = await _context.Companies.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(empresa);
            await _context.SaveChangesAsync();

            return Ok(empresa);
        }

        private bool EmpresaExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}