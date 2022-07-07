using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;
using TaskManually.Context;

namespace TaskManually.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly TaskContext _context;

        public MerchantsController(TaskContext context)
        {
            _context = context;
        }

        // GET: api/Merchants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchants>>> GetMerchants()
        {
          if (_context.Merchants == null)
          {
              return NotFound();
          }
            return await _context.Merchants.ToListAsync();
        }

        // GET: api/Merchants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Merchants>> GetMerchants(int id)
        {
          if (_context.Merchants == null)
          {
              return NotFound();
          }
            var merchants = await _context.Merchants.FindAsync(id);

            if (merchants == null)
            {
                return NotFound();
            }

            return merchants;
        }

        // PUT: api/Merchants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchants(int id, Merchants merchants)
        {
            if (id != merchants.Id)
            {
                return BadRequest();
            }

            _context.Entry(merchants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantsExists(id))
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

        // POST: api/Merchants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Merchants>> PostMerchants(Merchants merchants)
        {
          if (_context.Merchants == null)
          {
              return Problem("Entity set 'TaskContext.Merchants'  is null.");
          }
            _context.Merchants.Add(merchants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerchants", new { id = merchants.Id }, merchants);
        }

        // DELETE: api/Merchants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchants(int id)
        {
            if (_context.Merchants == null)
            {
                return NotFound();
            }
            var merchants = await _context.Merchants.FindAsync(id);
            if (merchants == null)
            {
                return NotFound();
            }

            _context.Merchants.Remove(merchants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MerchantsExists(int id)
        {
            return (_context.Merchants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
