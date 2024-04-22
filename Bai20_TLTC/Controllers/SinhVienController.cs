using Bai20_TLTC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bai20_TLTC.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly QuanlysinhvienContext _context;

        public SinhVienController(QuanlysinhvienContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sinhviens = _context.Sinhviens.ToList();
            return View(sinhviens);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSv, Ho, Ten, Dob, NoiSinh, DiaChi, Mobile, Email, Password, Status, Scmnd, Dantoc, TenViet, GioiTinh, Tel, EmailDct, DiemTs, AccNo, GhiChu, MaNh, TenKd, Specia, DiemRl, Qdtt, Cdrth, ScmndImg, CapDt, Ks")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhvien);
        }

        public IActionResult Edit(string id)
        {
            var sinhvien = _context.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            return View(sinhvien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSv, Ho, Ten, Dob, NoiSinh, DiaChi, Mobile, Email, Password, Status, Scmnd, Dantoc, TenViet, GioiTinh, Tel, EmailDct, DiemTs, AccNo, GhiChu, MaNh, TenKd, Specia, DiemRl, Qdtt, Cdrth, ScmndImg, CapDt, Ks")] Sinhvien editedSinhvien)
        {
            if (id != editedSinhvien.MaSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingSinhvien = await _context.Sinhviens.FindAsync(id);
                if (existingSinhvien == null)
                {
                    return NotFound();
                }

                try
                {
                    // Xóa sinh viên cũ
                    _context.Sinhviens.Remove(existingSinhvien);
                    await _context.SaveChangesAsync();

                    // Thêm sinh viên mới (đã chỉnh sửa) vào cơ sở dữ liệu
                    _context.Add(editedSinhvien);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhvienExists(editedSinhvien.MaSv))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(editedSinhvien);
        }

        public IActionResult Delete(string id)
        {
            var sinhvien = _context.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            return View(sinhvien);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhvien = await _context.Sinhviens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            _context.Sinhviens.Remove(sinhvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhvienExists(string maSv)
        {
            return _context.Sinhviens.Any(e => e.MaSv == maSv);
        }
    }
}
