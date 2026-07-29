using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DienThoaiWeb.Models;

namespace DienThoaiWeb.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly DienThoaiDbContext _context;

        public SanPhamController(DienThoaiDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sanPhams = _context.SanPhams.ToList();
            return View(sanPhams);
        }
        
        public IActionResult ChiTiet(string id)
        {
            // Kiểm tra mã sản phẩm null
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Truy vấn Database lấy sản phẩm theo MaSP
            var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.MaSP == id);

            // Xử lý 404 nếu không tìm thấy
            if (sanPham == null)
            {
                return NotFound();
            }

            // Trả Model sang View ChiTiet.cshtml
            return View(sanPham);
        }
    }
}
