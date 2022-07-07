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
    public class OrderitemsController : ControllerBase
    {
        private readonly TaskContext _context;

        public OrderitemsController(TaskContext context)
        {
            _context = context;
        }

        // GET: api/Orderitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderitems>>> Getorderitem()
        {
          if (_context.Orderitems == null)
          {
              return NotFound();
          }
            return await _context.Orderitems.ToListAsync();
        }

        // GET: api/Orderitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderitems>> GetOrderitems(int id)
        {
          if (_context.Orderitems == null)
          {
              return NotFound();
          }
            var orderitems = await _context.Orderitems.FindAsync(id);

            if (orderitems == null)
            {
                return NotFound();
            }

            return orderitems;
        }

        // PUT: api/Orderitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderitems(int id, Orderitems orderitems)
        {
            if (id != orderitems.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderitems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderitemsExists(id))
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

        // POST: api/Orderitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orderitems>> PostOrderitems(Orderitems orderitems)
        {
          if (_context.Orderitems == null)
          {
              return Problem("Entity set 'TaskContext.orderitem'  is null.");
          }
            _context.Orderitems.Add(orderitems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderitems", new { id = orderitems.Id }, orderitems);
        }

        // DELETE: api/Orderitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderitems(int id)
        {
            if (_context.Orderitems == null)
            {
                return NotFound();
            }
            var orderitems = await _context.Orderitems.FindAsync(id);
            if (orderitems == null)
            {
                return NotFound();
            }

            _context.Orderitems.Remove(orderitems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderitemsExists(int id)
        {
            return (_context.Orderitems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
