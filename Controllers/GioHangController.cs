using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBooks.Models;

namespace OnlineBooks.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        QuanLyBanSachEntities2 db = new QuanLyBanSachEntities2();
        public List<SanPhamGH> LayGioHang()
        {
            List<SanPhamGH> lstSP = Session["GioHang"] as List<SanPhamGH>;
            if (lstSP == null)
            {
                lstSP = new List<SanPhamGH>();
                Session["GioHang"] = lstSP;
            }
            return lstSP;
        }
        public ActionResult GioHang()
        {
            List<SanPhamGH> listSP = LayGioHang();
            int TongSL = 0;
            double TongTien = 0;
            foreach (var item in listSP)
            {
                TongSL += item.SoLuong;
                TongTien += item.TongTien;
            }
            Session["TongSL"] = TongSL.ToString();
            Session["TongTien"] = TongTien.ToString();
            return View(listSP);
        }
        [HttpPost]
        public ActionResult ThemGioHang(int iMaSP, int? SL)
        {
            List<SanPhamGH> lstSP = LayGioHang();
            SanPhamGH SP = lstSP.Find(n => n.MaSP == iMaSP);
            if (SP == null)
            {
                SP = new SanPhamGH();
                Sach Sach = db.Saches.Single(n => n.MaSach == iMaSP);
                SP.MaSP = iMaSP;
                SP.TenSP = Sach.TenSach;
                SP.AnhSP = Sach.AnhBia;
                SP.GiaSP = double.Parse(Sach.GiaBan.ToString());
                if (SL == null)
                {
                    SP.SoLuong = 1;
                }
                else
                {
                    SP.SoLuong = int.Parse(SL.ToString());
                }
                lstSP.Add(SP);
                
                Session["GioHang"] = lstSP;
                return Json(lstSP, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (SL == null)
                {
                    SP.SoLuong++;
                }
                else
                {
                    SP.SoLuong = int.Parse(SL.ToString());
                }
                Session["GioHang"] = lstSP;
                return Json(lstSP, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult XoaSP(int iMaSP)
        {
            List<SanPhamGH> lstSP = LayGioHang();
            SanPhamGH SP = lstSP.Find(n => n.MaSP == iMaSP);
            lstSP.Remove(SP);
            Session["GioHang"] = lstSP;
            return Json(lstSP, JsonRequestBehavior.AllowGet);
        }
    }
}