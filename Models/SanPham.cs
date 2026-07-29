using System.ComponentModel.DataAnnotations;

namespace DienThoaiWeb.Models
{
    public class SanPham
    {
        [Key]
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public string ThuongHieu { get; set; } = string.Empty;
        public string? HinhAnh { get; set; }
        public string? Gia { get; set; }
        public int SoSao { get; set; }
        public int SoDanhGia { get; set; }

        public string? KhuyenMai { get; set; }
        public string? GiaTriKhuyenMai { get; set; }

        public string? ManHinh { get; set; }
        public string? HeDieuHanh { get; set; }
        public string? CameraSau { get; set; }
        public string? CameraTruoc { get; set; }
        public string? CPU { get; set; }
        public string? RAM { get; set; }
        public string? ROM { get; set; }
        public string? TheNho { get; set; }
        public string? DungLuongPin { get; set; }
    }
}
