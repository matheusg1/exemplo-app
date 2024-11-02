using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiroTeste.Data;
using PrimeiroTeste.Models;

namespace PrimeiroTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteBDController : ControllerBase
    {
        private readonly DbPadraoContext _context;

        public ClienteBDController(DbPadraoContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCliente>>> GetTbClientes()
        {
            return await _context.TbClientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCliente>> GetTbCliente(long id)
        {
            var tbCliente = await _context.TbClientes.FindAsync(id);

            if (tbCliente == null)
            {
                return NotFound();
            }

            return tbCliente;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCliente(long id, TbCliente tbCliente)
        {
            if (id != tbCliente.ClieId)
            {
                return BadRequest();
            }

            _context.Entry(tbCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbClienteExists(id))
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

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCliente>> PostTbCliente(TbCliente tbCliente)
        {
            _context.TbClientes.Add(tbCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbCliente", new { id = tbCliente.ClieId }, tbCliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCliente(long id)
        {
            var tbCliente = await _context.TbClientes.FindAsync(id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            _context.TbClientes.Remove(tbCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbClienteExists(long id)
        {
            return _context.TbClientes.Any(e => e.ClieId == id);
        }
    }
}
