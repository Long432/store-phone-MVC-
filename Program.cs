using DienThoaiWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<DienThoaiDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DienThoaiDbContext>();
    // Cải tiến hệ thống: Gọi EnsureDeleted() để buộc EF Core xóa DB cũ 
    // và EnsureCreated() để tạo lại cấu trúc mới có bao gồm các thông số kỹ thuật
    // và danh sách sản phẩm mới (iPhone, Samsung cao cấp...).
    try { db.Database.EnsureDeleted(); } catch { }
    try { db.Database.EnsureCreated(); } catch { }

    // Sao chép 4 hình ảnh thật vừa tạo vào wwwroot (do CDN bên ngoài liên tục chặn)
    var imgDir = System.IO.Path.Combine(builder.Environment.WebRootPath, "img", "products");
    System.IO.Directory.CreateDirectory(imgDir);
    string basePath = @"C:\Users\Admin\.gemini\antigravity\brain\ea08bf9a-a2f6-4a42-9c0d-2b8f3724437d\";
    try { System.IO.File.Copy(basePath + "xiaomi_13_pro_1785040941459.png", imgDir + @"\xiaomi_13_pro.png", true); } catch { }
    try { System.IO.File.Copy(basePath + "redmi_note_12_1785040953772.png", imgDir + @"\redmi_note_12.png", true); } catch { }
    try { System.IO.File.Copy(basePath + "oppo_find_n2_flip_1785040965537.png", imgDir + @"\oppo_find_n2_flip.png", true); } catch { }
    try { System.IO.File.Copy(basePath + "oppo_reno10_1785040975387.png", imgDir + @"\oppo_reno10.png", true); } catch { }
}


if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
