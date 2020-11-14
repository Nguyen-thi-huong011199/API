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
    public class KhuvucsController : ControllerBase
    {
        private readonly Doan5Context _context;

        public KhuvucsController(Doan5Context context)
        {
            _context = context;
        }

        // GET: api/Khuvucs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khuvuc>>> GetKhuvuc()
        {
            return await _context.Khuvuc.ToListAsync();
        }

        // GET: api/Khuvucs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khuvuc>> GetKhuvuc(int id)
        {
            var khuvuc = await _context.Khuvuc.FindAsync(id);

            if (khuvuc == null)
            {
                return NotFound();
            }

            return khuvuc;
        }

        // PUT: api/Khuvucs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhuvuc(int id, Khuvuc khuvuc)
        {
            if (id != khuvuc.MaKv)
            {
                return BadRequest();
            }

            _context.Entry(khuvuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhuvucExists(id))
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

        // POST: api/Khuvucs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Khuvuc>> PostKhuvuc(Khuvuc khuvuc)
        {
            _context.Khuvuc.Add(khuvuc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhuvucExists(khuvuc.MaKv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhuvuc", new { id = khuvuc.MaKv }, khuvuc);
        }

        // DELETE: api/Khuvucs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Khuvuc>> DeleteKhuvuc(int id)
        {
            var khuvuc = await _context.Khuvuc.FindAsync(id);
            if (khuvuc == null)
            {
                return NotFound();
            }

            _context.Khuvuc.Remove(khuvuc);
            await _context.SaveChangesAsync();

            return khuvuc;
        }

        private bool KhuvucExists(int id)
        {
            return _context.Khuvuc.Any(e => e.MaKv == id);
        }
    }
}
