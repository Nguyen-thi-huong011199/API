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
    public class NhatuyendungsController : ControllerBase
    {
        private readonly Doan5Context _context;

        public NhatuyendungsController(Doan5Context context)
        {
            _context = context;
        }

        // GET: api/Nhatuyendungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nhatuyendung>>> GetNhatuyendung()
        {
            return await _context.Nhatuyendung.ToListAsync();
        }

        // GET: api/Nhatuyendungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nhatuyendung>> GetNhatuyendung(int id)
        {
            var nhatuyendung = await _context.Nhatuyendung.FindAsync(id);

            if (nhatuyendung == null)
            {
                return NotFound();
            }

            return nhatuyendung;
        }

        // PUT: api/Nhatuyendungs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhatuyendung(int id, Nhatuyendung nhatuyendung)
        {
            if (id != nhatuyendung.MaNtd)
            {
                return BadRequest();
            }

            _context.Entry(nhatuyendung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhatuyendungExists(id))
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

        // POST: api/Nhatuyendungs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nhatuyendung>> PostNhatuyendung(Nhatuyendung nhatuyendung)
        {
            _context.Nhatuyendung.Add(nhatuyendung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhatuyendungExists(nhatuyendung.MaNtd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNhatuyendung", new { id = nhatuyendung.MaNtd }, nhatuyendung);
        }

        // DELETE: api/Nhatuyendungs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nhatuyendung>> DeleteNhatuyendung(int id)
        {
            var nhatuyendung = await _context.Nhatuyendung.FindAsync(id);
            if (nhatuyendung == null)
            {
                return NotFound();
            }

            _context.Nhatuyendung.Remove(nhatuyendung);
            await _context.SaveChangesAsync();

            return nhatuyendung;
        }

        private bool NhatuyendungExists(int id)
        {
            return _context.Nhatuyendung.Any(e => e.MaNtd == id);
        }
    }
}
