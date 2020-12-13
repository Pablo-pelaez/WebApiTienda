using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTienda.Models;

namespace WebApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clienteItemsController : ControllerBase
    {
        private readonly clienteContext _context;

        public clienteItemsController(clienteContext context)
        {
            _context = context;
        }

        // GET: api/clienteItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<clienteItem>>> GetclienteItems()
        {
            return await _context.clienteItems.ToListAsync();
        }

        // GET: api/clienteItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<clienteItem>> GetclienteItem(long id)
        {
            var clienteItem = await _context.clienteItems.FindAsync(id);

            if (clienteItem == null)
            {
                return NotFound();
            }

            return clienteItem;
        }

        // PUT: api/clienteItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutclienteItem(long id, clienteItem clienteItem)
        {
            if (id != clienteItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteItemExists(id))
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

        // POST: api/clienteItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<clienteItem>> PostclienteItem(clienteItem clienteItem)
        {
            _context.clienteItems.Add(clienteItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetclienteItem", new { id = clienteItem.Id }, clienteItem);
            return CreatedAtAction(nameof(GetclienteItem), new { id = clienteItem.Id }, clienteItem);
        }

        // DELETE: api/clienteItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<clienteItem>> DeleteclienteItem(long id)
        {
            var clienteItem = await _context.clienteItems.FindAsync(id);
            if (clienteItem == null)
            {
                return NotFound();
            }

            _context.clienteItems.Remove(clienteItem);
            await _context.SaveChangesAsync();

            return clienteItem;
        }

        private bool clienteItemExists(long id)
        {
            return _context.clienteItems.Any(e => e.Id == id);
        }
    }
}
