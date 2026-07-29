using System.ComponentModel.DataAnnotations;

namespace DienThoaiWeb.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        public string TenKH { get; set; } = string.Empty;
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string TaiKhoan { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
    }
}
