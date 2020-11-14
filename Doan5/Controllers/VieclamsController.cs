using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doan5.Models;
using Doan5.Helper;
using Doan5.Services;

namespace Doan5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VieclamsController : ControllerBase
    {
        private readonly Doan5Context _context;
        private readonly IFileService _fileService;

        public VieclamsController(Doan5Context context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<Vieclam>> GetPage(int page, int pageSize)
        {
            var data = Pagination.GetPaged(_context.Vieclam, page, pageSize);

            return Ok(data);
        }

        // GET: api/Vieclams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vieclam>>> GetVieclam()
        {
            return await _context.Vieclam.ToListAsync();
        }

        // GET: api/Vieclams/5
        [HttpGet("{id}")]
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
        public async Task<IActionResult> PutProduct(int id, [FromBody] Dictionary<string, object> formData)
        {
            var vieclam = _context.Vieclam.Find(id);

            if (vieclam == null)
            {
                return BadRequest();
            }

            try
            {
                vieclam.MaloaiCv = int.Parse(formData["MaloaiCv"].ToString());
                vieclam.MaNtd = int.Parse(formData["MaNtd"].ToString());
                vieclam.MaKv = int.Parse(formData["MaKv"].ToString());
                vieclam.TenCv = formData["TenCv"].ToString();
                vieclam.Tencongty = formData["Tencongty"].ToString();
                vieclam.MotaCv = formData["MotaCv"].ToString();
                vieclam.Mucluong = formData["Mucluong"].ToString();
                vieclam.Diachi = formData["Diachi"].ToString();
                vieclam.Ngaydang = DateTime.Now;

                if (formData.ContainsKey("Anh"))
                {
                    var Image = formData["Anh"].ToString();

                    if ((vieclam.Anh = _fileService.WriteFileBase64(Image)) == null)
                    {
                        vieclam.Anh = "error.jpg";
                    }
                }

                await _context.SaveChangesAsync();
                return Ok();
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
        }

        // POST: api/Vieclams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vieclam>> PostVieclam ([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var vieclam = new Vieclam();

                vieclam.MaloaiCv = int.Parse(formData["MaloaiCv"].ToString());
                vieclam.MaNtd = int.Parse(formData["MaNtd"].ToString());
                vieclam.MaKv = int.Parse(formData["MaKv"].ToString());
                vieclam.TenCv = formData["TenCv"].ToString();
                vieclam.Tencongty = formData["Tencongty"].ToString();
                vieclam.MotaCv = formData["MotaCv"].ToString();
                vieclam.Mucluong = formData["Mucluong"].ToString();
                vieclam.Diachi = formData["Diachi"].ToString();
                vieclam.Luotxem = "1";
                vieclam.Ngaydang = DateTime.Now;

                vieclam.Anh = "error.jpg";
                if (formData.ContainsKey("Anh"))
                {
                    var Image = formData["Anh"].ToString();

                    if ((vieclam.Anh = _fileService.WriteFileBase64(Image)) == null)
                    {
                        vieclam.Anh = "error.jpg";
                    }
                }
                _context.Vieclam.Add(vieclam);
                await _context.SaveChangesAsync();

                return Ok(vieclam);
            }
            catch (Exception e)
            {
                return Ok(new { message = e.Message });
            }
        }

        [HttpGet("get-loai/{id}")]
        public IEnumerable<Vieclam> GetLoaiViecLam(int id)
        {
            var viecLam = _context.Vieclam.Where(vl => vl.MaloaiCv == id);

            return viecLam;
        }
        [HttpGet("get-loai-top4/{id}")]
        public IEnumerable<Vieclam> GetLoaiViecLamTop4(int id)
        {
            var viecLam = _context.Vieclam.Where(vl => vl.MaloaiCv == id).Take(4);

            return viecLam;
        }
        [HttpGet("get-loai-top6/{id}")]
        public IEnumerable<Vieclam> GetLoaiViecLamTop6(int id)
        {
            var viecLam = _context.Vieclam.Where(vl => vl.MaloaiCv == id).Take(6);

            return viecLam;
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
