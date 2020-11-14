using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doan5.Models;

namespace Doan5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HosoesController : ControllerBase
    {
        private readonly Doan5Context _context;

        public HosoesController(Doan5Context context)
        {
            _context = context;
        }

        // GET: api/Hosoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hoso>>> GetHoso()
        {
            return await _context.Hoso.ToListAsync();
        }

        // GET: api/Hosoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hoso>> GetHoso(int id)
        {
            var hoso = await _context.Hoso.FindAsync(id);

            if (hoso == null)
            {
                return NotFound();
            }

            return hoso;
        }

        // PUT: api/Hosoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoso(int id, Hoso hoso)
        {
            if (id != hoso.MaHs)
            {
                return BadRequest();
            }

            _context.Entry(hoso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HosoExists(id))
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

        // POST: api/Hosoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hoso>> PostHoso(Hoso hoso)
        {
            _context.Hoso.Add(hoso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HosoExists(hoso.MaHs))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHoso", new { id = hoso.MaHs }, hoso);
        }

        // DELETE: api/Hosoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hoso>> DeleteHoso(int id)
        {
            var hoso = await _context.Hoso.FindAsync(id);
            if (hoso == null)
            {
                return NotFound();
            }

            _context.Hoso.Remove(hoso);
            await _context.SaveChangesAsync();

            return hoso;
        }

        private bool HosoExists(int id)
        {
            return _context.Hoso.Any(e => e.MaHs == id);
        }
    }
}
