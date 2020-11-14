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
    public class NguoitimviecsController : ControllerBase
    {
        private readonly Doan5Context _context;

        public NguoitimviecsController(Doan5Context context)
        {
            _context = context;
        }

        // GET: api/Nguoitimviecs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nguoitimviec>>> GetNguoitimviec()
        {
            return await _context.Nguoitimviec.ToListAsync();
        }

        // GET: api/Nguoitimviecs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nguoitimviec>> GetNguoitimviec(int id)
        {
            var nguoitimviec = await _context.Nguoitimviec.FindAsync(id);

            if (nguoitimviec == null)
            {
                return NotFound();
            }

            return nguoitimviec;
        }

        // PUT: api/Nguoitimviecs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoitimviec(int id, Nguoitimviec nguoitimviec)
        {
            if (id != nguoitimviec.MaNtv)
            {
                return BadRequest();
            }

            _context.Entry(nguoitimviec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoitimviecExists(id))
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

        // POST: api/Nguoitimviecs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nguoitimviec>> PostNguoitimviec(Nguoitimviec nguoitimviec)
        {
            _context.Nguoitimviec.Add(nguoitimviec);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoitimviecExists(nguoitimviec.MaNtv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNguoitimviec", new { id = nguoitimviec.MaNtv }, nguoitimviec);
        }

        // DELETE: api/Nguoitimviecs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nguoitimviec>> DeleteNguoitimviec(int id)
        {
            var nguoitimviec = await _context.Nguoitimviec.FindAsync(id);
            if (nguoitimviec == null)
            {
                return NotFound();
            }

            _context.Nguoitimviec.Remove(nguoitimviec);
            await _context.SaveChangesAsync();

            return nguoitimviec;
        }

        private bool NguoitimviecExists(int id)
        {
            return _context.Nguoitimviec.Any(e => e.MaNtv == id);
        }
    }
}
