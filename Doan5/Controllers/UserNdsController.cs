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
    public class UserNdsController : ControllerBase
    {
        private readonly Doan5Context _context;

        public UserNdsController(Doan5Context context)
        {
            _context = context;
        }

        // GET: api/UserNds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserNd>>> GetUserNd()
        {
            return await _context.UserNd.ToListAsync();
        }

        // GET: api/UserNds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserNd>> GetUserNd(int id)
        {
            var userNd = await _context.UserNd.FindAsync(id);

            if (userNd == null)
            {
                return NotFound();
            }

            return userNd;
        }

        // PUT: api/UserNds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserNd(int id, UserNd userNd)
        {
            if (id != userNd.Mauser)
            {
                return BadRequest();
            }

            _context.Entry(userNd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserNdExists(id))
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

        // POST: api/UserNds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserNd>> PostUserNd(UserNd userNd)
        {
            _context.UserNd.Add(userNd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserNdExists(userNd.Mauser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserNd", new { id = userNd.Mauser }, userNd);
        }

        // DELETE: api/UserNds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserNd>> DeleteUserNd(int id)
        {
            var userNd = await _context.UserNd.FindAsync(id);
            if (userNd == null)
            {
                return NotFound();
            }

            _context.UserNd.Remove(userNd);
            await _context.SaveChangesAsync();

            return userNd;
        }

        private bool UserNdExists(int id)
        {
            return _context.UserNd.Any(e => e.Mauser == id);
        }
    }
}
