using Microsoft.AspNetCore.Mvc;

namespace DienThoaiWeb.Controllers
{
    public class DonHangController : Controller
    {
        public IActionResult GioHang()
        {
            return View();
        }
    }
}
