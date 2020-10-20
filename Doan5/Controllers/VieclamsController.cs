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
    public class VieclamsController : ControllerBase
    {
        private readonly Doan5Context _context;

        public VieclamsController(Doan5Context context)
        {
            _context = context;
        }

        // GET: api/Vieclams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vieclam>>> GetVieclam()
        {
            return await _context.Vieclam.ToListAsync();
        }

        // GET: api/Vieclams/5
        [HttpGet]
        public async Task<ActionResult<Vieclam>> GetVieclam(int id)
        {
            var vieclam = await _context.Vieclam.FindAsync(id);

            if (vieclam == null)
            {
                return NotFound();
            }

            return vieclam;
        }

        [HttpGet("tim-loai")]
        public IEnumerable<Vieclam> GetTimcongviec(int id, string key)
        {
            var viecLam = _context.Vieclam.Where(vl => vl.MaloaiCv == id && vl.TenCv.IndexOf(key) != -1);

            return viecLam;
        }

        [HttpGet("get-loai")]
        public IEnumerable<Vieclam> GetLoaicongviec(int id, int limit)
        {
            var viecLam = _context.Vieclam.Where(vl => vl.MaloaiCv == id).Take(limit);

            return viecLam;
        }

        // PUT: api/Vieclams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVieclam(int id, Vieclam vieclam)
        {
            if (id != vieclam.MaCv)
            {
                return BadRequest();
            }

            _context.Entry(vieclam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VieclamExists(id))
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

        // POST: api/Vieclams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vieclam>> PostVieclam(Vieclam vieclam)
        {
            _context.Vieclam.Add(vieclam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VieclamExists(vieclam.MaCv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVieclam", new { id = vieclam.MaCv }, vieclam);
        }

        // DELETE: api/Vieclams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vieclam>> DeleteVieclam(int id)
        {
            var vieclam = await _context.Vieclam.FindAsync(id);
            if (vieclam == null)
            {
                return NotFound();
            }

            _context.Vieclam.Remove(vieclam);
            await _context.SaveChangesAsync();

            return vieclam;
        }

        private bool VieclamExists(int id)
        {
            return _context.Vieclam.Any(e => e.MaCv == id);
        }
    }
}
