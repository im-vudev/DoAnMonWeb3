using DoAnMonWeb3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace DoAnMonWeb3.Service
{
    public class HoaDonService
    {
        private ApplicationDbContext _context;

        public HoaDonService(ApplicationDbContext context)
        {
            _context = context;
        }


        //public HoaDon AddHoaDon(HoaDon hoaDon, string[] DSDichVu, string[] DSGiaDichVu)
        //{
        //    hoaDon.DSdichVuSuDung = string.Join("</>", DSDichVu);
        //    hoaDon.DSGiaDichVuSuDung = string.Join("</>", DSGiaDichVu);

        //    _context.Add(hoaDon);
            
        //}
        //[Route("Admin/[controller]/[action]")]
        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var hoadon = new HoaDon { Id = id };
        //    context.Remove(hoadon);
        //    await context.SaveChangesAsync();
        //    toast.AddSuccessToastMessage("Xóa thành công hóa đơn", new ToastrOptions { Title = "Thông báo" });
        //    return RedirectToAction("Index");
        //}
        //[Route("Admin/[controller]/[action]")]
        //public async Task<IActionResult> Details(int id)
        //{
        //    HoaDon hoadon = await context.hoaDon.Include(x => x.thuePhong).Where(x => x.Id == id).FirstOrDefaultAsync();
        //    string[] dvsd = hoadon.DSdichVuSuDung.Split(new string[] { "</>" }, StringSplitOptions.RemoveEmptyEntries);
        //    string[] giadvsd = hoadon.DSGiaDichVuSuDung.Split(new string[] { "</>" }, StringSplitOptions.RemoveEmptyEntries);
        //    List<string> dichVuSuDung = new List<string>(dvsd);
        //    List<string> giaDichVuSuDung = new List<string>(giadvsd);
        //    ViewBag.DSDV = dichVuSuDung;
        //    ViewBag.GiaDVSD = giaDichVuSuDung;
        //    return View(hoadon);
        //}
        //[Route("Admin/[controller]/[action]")]
        //[HttpPost]
        //public async Task<IActionResult> Accept(int id)
        //{
        //    HoaDon hoadon = await context.hoaDon.Include(x => x.thuePhong).Where(x => x.Id == id).FirstOrDefaultAsync();
        //    hoadon.trangThai = 1;
        //    context.Update(hoadon);
        //    await context.SaveChangesAsync();
        //    toast.AddSuccessToastMessage("Duyệt thành công hóa đơn", new ToastrOptions { Title = "Thông báo" });
        //    return RedirectToAction("Index");
        //}
        //[Route("Admin/[controller]/[action]")]
        //[HttpPost]
        //public IActionResult Search(string tenPhong, Nullable<int> trangThai)
        //{
        //    List<SelectListItem> lstphong = new List<SelectListItem>();
        //    lstphong = context.phong.Select(x => new SelectListItem { Text = x.tenPhong, Value = x.tenPhong }).ToList();
        //    ViewBag.TenPhong = lstphong;
        //    if (!string.IsNullOrEmpty(tenPhong) && trangThai != null)
        //    {
        //        var hoadon = context.hoaDon.Where(x => x.tenPhong.ToLower().Contains(tenPhong.ToLower()) && x.trangThai == trangThai).ToList();
        //        return View("Index", hoadon.ToPagedList(1, 10));
        //    }
        //    else if (string.IsNullOrEmpty(tenPhong) && trangThai != null)
        //    {
        //        var hoadon = context.hoaDon.Where(x => x.trangThai == trangThai).ToList();
        //        return View("Index", hoadon.ToPagedList(1, 10));
        //    }
        //    else if (!string.IsNullOrEmpty(tenPhong) && trangThai == null)
        //    {
        //        var hoadon = context.hoaDon.Where(x => x.tenPhong.ToLower().Contains(tenPhong.ToLower())).ToList();
        //        return View("Index", hoadon.ToPagedList(1, 10));
        //    }
        //    else
        //    {
        //        var hoadon = context.hoaDon.ToList();
        //        return View("Index", hoadon.ToPagedList(1, 10));
        //    }
        //}
        //[Route("Admin/[controller]/[action]")]
        //[HttpPost]
        //public async Task<IActionResult> ClientPaid(int id)
        //{
        //    var hoadon = await context.hoaDon.Where(x => x.Id == id).FirstOrDefaultAsync();
        //    hoadon.trangThai = 2;
        //    context.Update(hoadon);
        //    await context.SaveChangesAsync();
        //    return Redirect("~/HoaDonVaBienLai/Index");
        //}
    }
}
