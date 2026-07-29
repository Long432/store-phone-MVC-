using System;
using System.ComponentModel.DataAnnotations;

namespace DienThoaiWeb.Models
{
    public class DonHang
    {
        [Key]
        public int MaDH { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayDat { get; set; }
        public string TrangThai { get; set; } = string.Empty;
        public decimal TongTien { get; set; }
        
        public KhachHang? KhachHang { get; set; }
    }
}
