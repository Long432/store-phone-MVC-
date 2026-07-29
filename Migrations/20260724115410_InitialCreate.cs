using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DienThoaiWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenKH = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: true),
                    TaiKhoan = table.Column<string>(type: "TEXT", nullable: false),
                    MatKhau = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "TEXT", nullable: false),
                    TenSP = table.Column<string>(type: "TEXT", nullable: false),
                    ThuongHieu = table.Column<string>(type: "TEXT", nullable: false),
                    HinhAnh = table.Column<string>(type: "TEXT", nullable: true),
                    Gia = table.Column<string>(type: "TEXT", nullable: true),
                    SoSao = table.Column<int>(type: "INTEGER", nullable: false),
                    SoDanhGia = table.Column<int>(type: "INTEGER", nullable: false),
                    KhuyenMai = table.Column<string>(type: "TEXT", nullable: true),
                    GiaTriKhuyenMai = table.Column<string>(type: "TEXT", nullable: true),
                    ManHinh = table.Column<string>(type: "TEXT", nullable: true),
                    HeDieuHanh = table.Column<string>(type: "TEXT", nullable: true),
                    CameraSau = table.Column<string>(type: "TEXT", nullable: true),
                    CameraTruoc = table.Column<string>(type: "TEXT", nullable: true),
                    CPU = table.Column<string>(type: "TEXT", nullable: true),
                    RAM = table.Column<string>(type: "TEXT", nullable: true),
                    ROM = table.Column<string>(type: "TEXT", nullable: true),
                    TheNho = table.Column<string>(type: "TEXT", nullable: true),
                    DungLuongPin = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSP);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    MaDH = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaKH = table.Column<int>(type: "INTEGER", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: false),
                    TongTien = table.Column<decimal>(type: "TEXT", nullable: false),
                    KhachHangMaKH = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.MaDH);
                    table.ForeignKey(
                        name: "FK_DonHangs_KhachHangs_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH");
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "MaSP", "CPU", "CameraSau", "CameraTruoc", "DungLuongPin", "Gia", "GiaTriKhuyenMai", "HeDieuHanh", "HinhAnh", "KhuyenMai", "ManHinh", "RAM", "ROM", "SoDanhGia", "SoSao", "TenSP", "TheNho", "ThuongHieu" },
                values: new object[,]
                {
                    { "Opp0", null, "16 MP và 2 MP (2 camera)", "25 MP", null, "7.690.000", null, "ColorOS 5.2 (Android 8.1)", "img/products/oppo-f9-red-600x600.jpg", null, "LTPS LCD, 6.3', Full HD+", null, null, 188, 5, "Oppo F9", null, "Oppo" },
                    { "Sam0", null, "13 MP", "5 MP", null, "3.490.000", null, "Android 8.1 (Oreo)", "img/products/samsung-galaxy-j4-plus-pink-400x400.jpg", null, "IPS LCD, 6.0', HD+", null, null, 26, 3, "SamSung Galaxy J4+", null, "Samsung" },
                    { "Xia0", null, "12 MP và 5 MP (2 camera)", "24 MP", null, "6.690.000", null, "Android 8.1 (Oreo)", "img/products/xiaomi-mi-8-lite-black-1-600x600.jpg", null, "IPS LCD, 6.26', Full HD+", null, null, 0, 0, "Xiaomi Mi 8 Lite", null, "Xiaomi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_KhachHangMaKH",
                table: "DonHangs",
                column: "KhachHangMaKH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
