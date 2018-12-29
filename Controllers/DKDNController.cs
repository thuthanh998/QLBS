using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using OnlineBooks.Models;

namespace OnlineBooks.Controllers
{
    public class DKDNController : Controller
    {
        QuanLyBanSachEntities2 db = new QuanLyBanSachEntities2();
        // GET: DKDN
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection frmDK, KhachHang KH)
        {
            KH.HoTen = frmDK["HoTen"];
            KH.GioiTinh = frmDK["GioiTinh"];
            KH.Email = frmDK["Email"];
            KH.DiaChi = frmDK["DiaChi"];
            KH.DienThoai = frmDK["SDT"];
            KH.NgaySinh = DateTime.Parse(frmDK["NgaySinh"]);
            KH.TaiKhoan = frmDK["TenDN"];
            KH.MatKhau = GetMD5(frmDK["MatKhau"]);
            db.KhachHangs.Add(KH);
            db.SaveChanges();
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection frmDN)
        {
            string sTaiKhoan = frmDN["TaiKhoan"];
            string sMatKhau = GetMD5(frmDN["MK"]);
            KhachHang KH = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if(KH != null)
            {
                Session["KhachHang"] = KH.MaKH;
                Session["TenKH"] = KH.HoTen;
                Session["ThongBao"] = "";
                return RedirectToAction("ViewTrangChu", "TrangChu");
            }
            Session["ThongBao"] = "Mật Khẩu Hoặc Tài Khoản Không Chính Xác!";
            return RedirectToAction("DangNhap","DKDN");
        }
        public ActionResult DangXuat()
        {
            Session["KhachHang"] = null;
            Session["TenKH"] = null;
            Session["ThongBao"] = "";
            return RedirectToAction("ViewTrangChu", "TrangChu");
        }
        public ActionResult ThongTinCaNhan()
        {
            if(Session["KhachHang"] == null)
            {
                return RedirectToAction("DangNhap", "DKDN");
            }
            else
            {
                int MaKH = int.Parse(Session["KhachHang"].ToString());
                KhachHang KH = db.KhachHangs.Single(n => n.MaKH == MaKH);
                return View(KH);
            }
           
        }
        [HttpPost]
        public ActionResult CapNhatThongTin(string HoTen, string GioiTinh, string Email, string DiaChi, string SDT,string NgaySinh,int MaKH, KhachHang KH)
        {
            KH = db.KhachHangs.Single(n => n.MaKH == MaKH);
            KH.HoTen = HoTen;
            KH.GioiTinh = GioiTinh;
            KH.Email = Email;
            KH.DiaChi = DiaChi;
            KH.DienThoai = SDT;
            KH.NgaySinh = DateTime.Parse(NgaySinh);
            db.Entry(KH);
            db.SaveChanges();
            return Json("Cập Nhật Thành Công!");
        }
        [HttpPost]
        public ActionResult CapNhatMatKhau(int MaKH, string MatKhauCu,string MatKhauMoi)
        {
            KhachHang KH = db.KhachHangs.Single(n => n.MaKH == MaKH);
            string MK = GetMD5(MatKhauCu);
            string MKMoi = GetMD5(MatKhauMoi);
            if (MK == KH.MatKhau)
            {
                KH.MatKhau = MKMoi;
                db.Entry(KH);
                db.SaveChanges();
                return Json("true");
            }
            else
            {
                return Json("false");
            }
        }
        public string GetMD5(string MD5)
        {
            string str = "";
            byte[] A = System.Text.Encoding.UTF8.GetBytes(MD5);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            A = md5.ComputeHash(A);
            foreach (Byte b in A)
            {
                str += b.ToString("X2");
            }
            return str;
        }
    }
}