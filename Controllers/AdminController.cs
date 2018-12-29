using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBooks.Models;
using System.IO;

namespace OnlineBooks.Controllers
{
    public class AdminController : Controller
    {
        QuanLyBanSachEntities2 db = new QuanLyBanSachEntities2();
        // GET: Admin
        public ActionResult TrangChuAd()
        {
            if(Session["Admin"] == null)
            {
                return RedirectToAction("DangNhapAD", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SachAD()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("DangNhapAD", "Admin");
            }
            else
            {
                return View(db.Saches.ToList());
            }
            
        }
        public ActionResult ThemSach()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult ThemSach(FormCollection frm, Sach sach,HttpPostedFileBase AnhBia)
        {
            if (AnhBia != null)
            {
                string path = Server.MapPath("~/Content/Images/product/");
                AnhBia.SaveAs(path + Path.GetFileName(AnhBia.FileName));
                sach.TenSach = frm["TenSach"];
                sach.GiaBan = decimal.Parse(frm["Giaban"]);
                sach.MoTa = frm["MoTa"];
                sach.AnhBia = AnhBia.FileName;
                sach.NgayCapNhat = DateTime.Parse(frm["NgayCapNhat"]);
                sach.SoLuongTon = int.Parse(frm["SoLuong"]);
                sach.MaNXB = int.Parse(frm["MaNXB"]);
                sach.MaChuDe = int.Parse(frm["MaCD"]);
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("SachAD", "Admin");
            }
            else
            {
                return RedirectToAction("ThemSach", "Admin");
            }
        }
        public ActionResult DangNhapAD()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapAD(FormCollection frm, Admin ad)
        {
            string sTaiKhoan = frm["TaiKhoanAD"];
            string sMatKhau = frm["MatKhau"];
            ad = db.Admins.SingleOrDefault(n => n.TaiKhoanAd == sTaiKhoan && n.MatKhauAd == sMatKhau);
            if(ad == null)
            {
                ViewBag.Tb = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác!";
                return RedirectToAction("DangNhapAD", "Admin");
            }
            else
            {
                Session["Admin"] = ad.MaAd;
                Session["TenAd"] = ad.HoTenAd;
                return RedirectToAction("TrangChuAD", "Admin");
            }
        }
    }
}