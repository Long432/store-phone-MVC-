using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DienThoaiWeb.Models;
using System.Linq;
using System.Collections.Generic;

namespace DienThoaiWeb.Controllers
{
    public class GioHangController : Controller
    {
        private readonly DienThoaiDbContext _context;

        public GioHangController(DienThoaiDbContext context)
        {
            _context = context;
        }

        // Lấy giỏ hàng từ Session
        private List<CartItem> GetCartItems()
        {
            var sessionData = HttpContext.Session.GetString("GioHang");
            if (sessionData == null) return new List<CartItem>();
            return JsonSerializer.Deserialize<List<CartItem>>(sessionData);
        }

        // Lưu giỏ hàng vào Session
        private void SaveCartItems(List<CartItem> ls)
        {
            var sessionData = JsonSerializer.Serialize(ls);
            HttpContext.Session.SetString("GioHang", sessionData);
        }

        public IActionResult Index()
        {
            return View(GetCartItems());
        }

        [HttpPost]
        public IActionResult ThemVaoGioHang(string maSp)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(c => c.MaSP == maSp);

            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                var sp = _context.SanPhams.FirstOrDefault(s => s.MaSP == maSp);
                if (sp == null) return NotFound();

                // Lọc bỏ dấu chấm trong giá để chuyển thành decimal (VD: "28.590.000" -> 28590000)
                decimal donGia = 0;
                var rawGia = sp.Gia.Replace(".", "").Replace("đ", "").Trim();
                decimal.TryParse(rawGia, out donGia);

                cart.Add(new CartItem
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    HinhAnh = sp.HinhAnh,
                    DonGia = donGia,
                    SoLuong = 1
                });
            }

            SaveCartItems(cart);
            return Ok(new { success = true, totalCount = cart.Sum(c => c.SoLuong) });
        }

        public IActionResult XoaKhoiGioHang(string maSp)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(c => c.MaSP == maSp);
            if (item != null)
            {
                cart.Remove(item);
                SaveCartItems(cart);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CapNhatSoLuong(string maSp, int soLuong)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(c => c.MaSP == maSp);

            if (item != null)
            {
                if (soLuong <= 0)
                {
                    cart.Remove(item);
                }
                else
                {
                    item.SoLuong = soLuong;
                }
                SaveCartItems(cart);
                return Ok(new { success = true, totalCount = cart.Sum(c => c.SoLuong), itemTotal = item.ThanhTien, cartTotal = cart.Sum(c => c.ThanhTien) });
            }
            return NotFound();
        }

        public IActionResult ThanhToan()
        {
            var cart = GetCartItems();
            if (cart.Count == 0) return RedirectToAction("Index");
            return View(cart);
        }

        [HttpPost]
        public IActionResult XacNhanThanhToan(string hoTen, string sdt, string diaChi, string ghiChu)
        {
            var cart = GetCartItems();
            if (cart.Count == 0) return RedirectToAction("Index");

            // Xóa session giỏ hàng sau khi đặt thành công
            HttpContext.Session.Remove("GioHang");

            // Tạo mã đơn ngẫu nhiên để mô phỏng
            string maDon = "LDD-" + new System.Random().Next(100000, 999999).ToString();
            return View("ThanhCong", model: maDon);
        }
    }
}
