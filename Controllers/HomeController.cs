using Microsoft.AspNetCore.Mvc;
using DienThoaiWeb.Models;
using System.Linq;

namespace DienThoaiWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DienThoaiDbContext _context;

        public HomeController(DienThoaiDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search, string gia, string sapXep)
        {
            var query = _context.SanPhams.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(sp => sp.TenSP.ToLower().Contains(search.ToLower()) || sp.ThuongHieu.ToLower().Contains(search.ToLower()));
            }

            var sanPhams = query.ToList(); 

            if (!string.IsNullOrEmpty(gia))
            {
                if (gia == "duoi-10") sanPhams = sanPhams.Where(sp => GetNumericPrice(sp.Gia) < 10000000).ToList();
                else if (gia == "10-20") sanPhams = sanPhams.Where(sp => GetNumericPrice(sp.Gia) >= 10000000 && GetNumericPrice(sp.Gia) <= 20000000).ToList();
                else if (gia == "tren-20") sanPhams = sanPhams.Where(sp => GetNumericPrice(sp.Gia) > 20000000).ToList();
            }

            if (!string.IsNullOrEmpty(sapXep))
            {
                if (sapXep == "gia-tang") sanPhams = sanPhams.OrderBy(sp => GetNumericPrice(sp.Gia)).ToList();
                else if (sapXep == "gia-giam") sanPhams = sanPhams.OrderByDescending(sp => GetNumericPrice(sp.Gia)).ToList();
            }

            return View(sanPhams);
        }

        private decimal GetNumericPrice(string giaStr)
        {
            if (string.IsNullOrEmpty(giaStr)) return 0;
            string raw = giaStr.Replace(".", "").Replace("đ", "").Replace(" ", "").Trim();
            decimal.TryParse(raw, out decimal val);
            return val;
        }

        public IActionResult TinTuc() => View();
        public IActionResult TuyenDung() => View();
        public IActionResult GioiThieu() => View();
        public IActionResult BaoHanh() => View();
        public IActionResult LienHe() => View();
        public IActionResult Admin() => View();
        public IActionResult NguoiDung() => View();
    }
}
