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
    public class LoaicongviecsController : ControllerBase
    {
        private readonly Doan5Context _context;

        public LoaicongviecsController(Doan5Context context)
        {
            _context = context;
        }

        // GET: api/Loaicongviecs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loaicongviec>>> GetLoaicongviec()
        {
            return await _context.Loaicongviec.ToListAsync();
        }

        // GET: api/Loaicongviecs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loaicongviec>> GetLoaicongviec(int id)
        {
            var loaicongviec = await _context.Loaicongviec.FindAsync(id);

            if (loaicongviec == null)
            {
                return NotFound();
            }

            return loaicongviec;
        }

        // PUT: api/Loaicongviecs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaicongviec(int id, Loaicongviec loaicongviec)
        {
            if (id != loaicongviec.MaloaiCv)
            {
                return BadRequest();
            }

            _context.Entry(loaicongviec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaicongviecExists(id))
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

        // POST: api/Loaicongviecs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Loaicongviec>> PostLoaicongviec(Loaicongviec loaicongviec)
        {
            _context.Loaicongviec.Add(loaicongviec);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaicongviecExists(loaicongviec.MaloaiCv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoaicongviec", new { id = loaicongviec.MaloaiCv }, loaicongviec);
        }

        // DELETE: api/Loaicongviecs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loaicongviec>> DeleteLoaicongviec(int id)
        {
            var loaicongviec = await _context.Loaicongviec.FindAsync(id);
            if (loaicongviec == null)
            {
                return NotFound();
            }

            _context.Loaicongviec.Remove(loaicongviec);
            await _context.SaveChangesAsync();

            return loaicongviec;
        }

        private bool LoaicongviecExists(int id)
        {
            return _context.Loaicongviec.Any(e => e.MaloaiCv == id);
        }
    }
}
