using Bai20_TLTC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bai20_TLTC.Controllers
{
    public class GiaoVienController : Controller
    {
        private readonly QuanlysinhvienContext _context;

        public GiaoVienController(QuanlysinhvienContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var giaoviens = _context.GiaoViens.ToList();
            return View(giaoviens);
        }

        public IActionResult Edit(string id)
        {
            var giaovien = _context.GiaoViens.Find(id);
            if (giaovien == null)
            {
                return NotFound();
            }
            return View(giaovien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaGv, HoTenGv, Dob, DiaChi, Mobile, Email, Password, Status")] GiaoVien giaovien)
        {
            if (id != giaovien.MaGv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaovien);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaoVienExists(giaovien.MaGv))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(giaovien);
        }

        public IActionResult Delete(string id)
        {
            var giaovien = _context.GiaoViens.Find(id);
            if (giaovien == null)
            {
                return NotFound();
            }
            return View(giaovien);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var giaovien = await _context.GiaoViens.FindAsync(id);
            if (giaovien == null)
            {
                return NotFound();
            }

            _context.GiaoViens.Remove(giaovien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGv, HoTenGv, Dob, DiaChi, Mobile, Email, Password, Status")] GiaoVien giaovien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaovien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaovien);
        }

        private bool GiaoVienExists(string maGv)
        {
            return _context.GiaoViens.Any(e => e.MaGv == maGv);
        }
    }
}
