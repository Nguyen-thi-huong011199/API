using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doan5.Models;
using Doan5.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Doan5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoansController : ControllerBase
    {
        private readonly Doan5Context _context;
        private readonly IAuthService _authService;

        public TaikhoansController(Doan5Context context, IAuthService userService)
        {
            _context = context;
            _authService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] Dictionary<string, object> formData)
        {
            var username = formData["username"].ToString();
            var password = formData["password"].ToString();
            var user = _authService.Authenticate(username, password);

            if (user == null)
                return BadRequest(new { status = 0, message = "Tài khoản hoặc mật khẩu không chính xác" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.MaTk.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                user,
                token = tokenString
            });
        }

        [HttpGet("register")]
        public IActionResult Register([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                // create user default
                var u = new UserNd();

                var user = new Taikhoan();

                user.

                return Ok(user);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Taikhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taikhoan>>> GetTaikhoan()
        {
            return await _context.Taikhoan.ToListAsync();
        }

        // GET: api/Taikhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taikhoan>> GetTaikhoan(int id)
        {
            var taikhoan = await _context.Taikhoan.FindAsync(id);

            if (taikhoan == null)
            {
                return NotFound();
            }

            return taikhoan;
        }

        // PUT: api/Taikhoans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaikhoan(int id, Taikhoan taikhoan)
        {
            if (id != taikhoan.MaTk)
            {
                return BadRequest();
            }

            _context.Entry(taikhoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaikhoanExists(id))
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

        // POST: api/Taikhoans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Taikhoan>> PostTaikhoan(Taikhoan taikhoan)
        {
            _context.Taikhoan.Add(taikhoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaikhoanExists(taikhoan.MaTk))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaikhoan", new { id = taikhoan.MaTk }, taikhoan);
        }

        // DELETE: api/Taikhoans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Taikhoan>> DeleteTaikhoan(int id)
        {
            var taikhoan = await _context.Taikhoan.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            _context.Taikhoan.Remove(taikhoan);
            await _context.SaveChangesAsync();

            return taikhoan;
        }

        private bool TaikhoanExists(int id)
        {
            return _context.Taikhoan.Any(e => e.MaTk == id);
        }
    }
}
