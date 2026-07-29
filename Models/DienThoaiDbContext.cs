using Microsoft.EntityFrameworkCore;

namespace DienThoaiWeb.Models
{
    // Cập nhật DB

    public class DienThoaiDbContext : DbContext
    {
        public DienThoaiDbContext(DbContextOptions<DienThoaiDbContext> options) : base(options)
        {
        }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham { MaSP = "Sam0", TenSP = "Samsung Galaxy S23 Ultra", ThuongHieu = "Samsung", Gia = "15.990.000", HinhAnh = "https://cdn.tgdd.vn/Products/Images/42/249948/samsung-galaxy-s23-ultra-1-600x600.jpg", SoSao = 5, SoDanhGia = 302, ManHinh = "Dynamic AMOLED 2X, 6.8', Quad HD+", HeDieuHanh = "Android 13", CameraSau = "200 MP, 10 MP, 10 MP, 12 MP", CameraTruoc = "12 MP", CPU = "Snapdragon 8 Gen 2 for Galaxy", RAM = "12 GB", ROM = "512 GB", TheNho = "Không", DungLuongPin = "5000 mAh", KhuyenMai = "Mới ra mắt", GiaTriKhuyenMai = "" },
                
                new SanPham { MaSP = "Sam1", TenSP = "Samsung Galaxy Z Fold4", ThuongHieu = "Samsung", Gia = "14.990.000", HinhAnh = "https://cdn.tgdd.vn/Products/Images/42/250625/samsung-galaxy-z-fold4-kem-256gb-600x600.jpg", SoSao = 4, SoDanhGia = 86, ManHinh = "Dynamic AMOLED 2X, 7.6' & 6.2'", HeDieuHanh = "Android 12", CameraSau = "50 MP, 12 MP, 10 MP", CameraTruoc = "10 MP & 4 MP", CPU = "Snapdragon 8+ Gen 1", RAM = "12 GB", ROM = "512 GB", TheNho = "Không", DungLuongPin = "4400 mAh", KhuyenMai = "Giá rẻ online", GiaTriKhuyenMai = "" },

                new SanPham { MaSP = "Sam2", TenSP = "Samsung Galaxy S22 Ultra", ThuongHieu = "Samsung", Gia = "10.990.000", HinhAnh = "https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:80/plain/https://cellphones.com.vn/media/catalog/product/s/m/sm-s908_galaxys22ultra_front_burgundy_211119_2.jpg", SoSao = 5, SoDanhGia = 112, ManHinh = "Dynamic AMOLED 2X, 6.8', Quad HD+", HeDieuHanh = "Android 12", CameraSau = "108 MP, 10 MP, 10 MP, 12 MP", CameraTruoc = "40 MP", CPU = "Snapdragon 8 Gen 1", RAM = "8 GB", ROM = "256 GB", TheNho = "Không", DungLuongPin = "5000 mAh", KhuyenMai = "Giảm giá", GiaTriKhuyenMai = "500.000đ" },

                new SanPham { MaSP = "Sam3", TenSP = "Samsung Galaxy A54 5G", ThuongHieu = "Samsung", Gia = "5.490.000", HinhAnh = "https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:80/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-galaxy-a54.png", SoSao = 4, SoDanhGia = 56, ManHinh = "Super AMOLED, 6.4', Full HD+", HeDieuHanh = "Android 13", CameraSau = "50 MP, 12 MP, 5 MP", CameraTruoc = "32 MP", CPU = "Exynos 1380", RAM = "8 GB", ROM = "128 GB", TheNho = "MicroSD", DungLuongPin = "5000 mAh", KhuyenMai = "", GiaTriKhuyenMai = "" },

                new SanPham { MaSP = "Iph0", TenSP = "iPhone 14 Pro Max 256GB", ThuongHieu = "Apple", Gia = "16.990.000", HinhAnh = "https://cdn.tgdd.vn/Products/Images/42/289700/iphone-14-pro-max-den-thumb-600x600.jpg", SoSao = 5, SoDanhGia = 899, ManHinh = "OLED, 6.7', Super Retina XDR", HeDieuHanh = "iOS 16", CameraSau = "48 MP, 12 MP, 12 MP", CameraTruoc = "12 MP", CPU = "Apple A16 Bionic", RAM = "6 GB", ROM = "256 GB", TheNho = "Không", DungLuongPin = "4323 mAh", KhuyenMai = "Mới ra mắt", GiaTriKhuyenMai = "" },
                
                new SanPham { MaSP = "Iph1", TenSP = "iPhone 13 128GB", ThuongHieu = "Apple", Gia = "8.990.000", HinhAnh = "https://cdn.tgdd.vn/Products/Images/42/223602/iphone-13-pink-2-600x600.jpg", SoSao = 5, SoDanhGia = 450, ManHinh = "OLED, 6.1', Super Retina XDR", HeDieuHanh = "iOS 15", CameraSau = "2 camera 12 MP", CameraTruoc = "12 MP", CPU = "Apple A15 Bionic", RAM = "4 GB", ROM = "128 GB", TheNho = "Không", DungLuongPin = "3240 mAh", KhuyenMai = "Giảm giá", GiaTriKhuyenMai = "1.500.000đ" },

                new SanPham { MaSP = "Iph2", TenSP = "iPhone 15 Pro 256GB", ThuongHieu = "Apple", Gia = "19.670.000", HinhAnh = "https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:80/plain/https://cellphones.com.vn/media/catalog/product/i/p/iphone-15-pro-256gb_1.png", SoSao = 5, SoDanhGia = 241, ManHinh = "OLED, 6.1', Super Retina XDR", HeDieuHanh = "iOS 17", CameraSau = "48 MP, 12 MP, 12 MP", CameraTruoc = "12 MP", CPU = "Apple A17 Pro", RAM = "8 GB", ROM = "256 GB", TheNho = "Không", DungLuongPin = "3274 mAh", KhuyenMai = "Mới ra mắt", GiaTriKhuyenMai = "" },

                new SanPham { MaSP = "Iph3", TenSP = "iPhone 11 64GB", ThuongHieu = "Apple", Gia = "4.990.000", HinhAnh = "https://cdn.tgdd.vn/Products/Images/42/153856/iphone-11-trang-600x600.jpg", SoSao = 4, SoDanhGia = 1500, ManHinh = "IPS LCD, 6.1', Liquid Retina", HeDieuHanh = "iOS 13", CameraSau = "2 camera 12 MP", CameraTruoc = "12 MP", CPU = "Apple A13 Bionic", RAM = "4 GB", ROM = "64 GB", TheNho = "Không", DungLuongPin = "3110 mAh", KhuyenMai = "Giá rẻ online", GiaTriKhuyenMai = "" },

                new SanPham { MaSP = "Xia0", TenSP = "Xiaomi 13 Pro 5G", ThuongHieu = "Xiaomi", Gia = "10.990.000", HinhAnh = "/img/products/xiaomi_13_pro.png", SoSao = 4, SoDanhGia = 120, ManHinh = "AMOLED, 6.73', 2K+", HeDieuHanh = "Android 13", CameraSau = "50 MP, 50 MP, 50 MP", CameraTruoc = "32 MP", CPU = "Snapdragon 8 Gen 2", RAM = "12 GB", ROM = "256 GB", TheNho = "Không", DungLuongPin = "4820 mAh", KhuyenMai = "Giảm giá", GiaTriKhuyenMai = "2.000.000đ" },

                new SanPham { MaSP = "Xia1", TenSP = "Xiaomi Redmi Note 12", ThuongHieu = "Xiaomi", Gia = "2.990.000", HinhAnh = "/img/products/redmi_note_12.png", SoSao = 4, SoDanhGia = 632, ManHinh = "AMOLED, 6.67', Full HD+", HeDieuHanh = "Android 13", CameraSau = "50 MP, 8 MP, 2 MP", CameraTruoc = "13 MP", CPU = "Snapdragon 685", RAM = "4 GB", ROM = "128 GB", TheNho = "MicroSD", DungLuongPin = "5000 mAh", KhuyenMai = "Giá rẻ online", GiaTriKhuyenMai = "" },

                new SanPham { MaSP = "Opp0", TenSP = "Oppo Find N2 Flip", ThuongHieu = "Oppo", Gia = "9.990.000", HinhAnh = "/img/products/oppo_find_n2_flip.png", SoSao = 5, SoDanhGia = 188, ManHinh = "AMOLED, 6.8', Full HD+", HeDieuHanh = "Android 13", CameraSau = "50 MP, 8 MP", CameraTruoc = "32 MP", CPU = "Dimensity 9000+", RAM = "8 GB", ROM = "256 GB", TheNho = "Không", DungLuongPin = "4300 mAh", KhuyenMai = "Trả góp", GiaTriKhuyenMai = "" },

                new SanPham { MaSP = "Opp1", TenSP = "Oppo Reno10 5G", ThuongHieu = "Oppo", Gia = "5.990.000", HinhAnh = "/img/products/oppo_reno10.png", SoSao = 5, SoDanhGia = 95, ManHinh = "AMOLED, 6.7', Full HD+", HeDieuHanh = "Android 13", CameraSau = "64 MP, 32 MP, 8 MP", CameraTruoc = "32 MP", CPU = "Dimensity 7050", RAM = "8 GB", ROM = "256 GB", TheNho = "MicroSD", DungLuongPin = "5000 mAh", KhuyenMai = "Mới ra mắt", GiaTriKhuyenMai = "" }
            );
        }
    }
}
