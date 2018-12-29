using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBooks.Models;

namespace OnlineBooks.Controllers
{
    public class ViewSachController : Controller
    {
        QuanLyBanSachEntities2 db = new QuanLyBanSachEntities2();

        // GET: ViewSach
        public ActionResult SachTheoChuDe(int? MaCD)
        {
            return View(db.Saches.Where(n => n.MaChuDe == MaCD).ToList());
        }
        public ActionResult ChiTietSach(int? MaSach)
        {
            if (MaSach == null)
            {
                MaSach = int.Parse(TempData["MaSach"].ToString());
                int MaTG = db.ThamGias.SingleOrDefault(n => n.MaSach == MaSach && n.VaiTro == "Tác Giả").MaTacGia;
                ViewBag.TenTG = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTG).TenTacGia;
                List<DanhGia> DG = db.DanhGias.Where(n => n.MaSach == MaSach).OrderByDescending(n => n.MaDanhGia).ToList();
                ViewData["listDG"] = DG;
                List<DanhGia> LDG = db.DanhGias.Where(n => n.MaSach == MaSach).ToList();
                double DGTB = 0;
                int DiemDG = 0;
                for (int i = 0; i < LDG.Count(); i++)
                {
                    DiemDG += int.Parse(LDG[i].DiemDG.ToString());
                }
                DGTB = DiemDG / LDG.Count();

                return View(db.Saches.SingleOrDefault(n => n.MaSach == MaSach));
            }
            else
            {
                int MaTG = db.ThamGias.SingleOrDefault(n => n.MaSach == MaSach && n.VaiTro == "Tác Giả").MaTacGia;
                ViewBag.TenTG = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTG).TenTacGia;
                List<DanhGia> DG = db.DanhGias.Where(n => n.MaSach == MaSach).OrderByDescending(n => n.MaDanhGia).ToList();
                ViewData["listDG"] = DG;
                return View(db.Saches.SingleOrDefault(n => n.MaSach == MaSach));
            }
        }
        //public ActionResult Rating()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult ChiTietSach(int iMaSach,string iName,string iComment,string Ngay,int iRating, DanhGia DG)
        {
            DG.MaSach = iMaSach;
            DG.TenKhachHang = iName;
            DG.cmtDanhGia = iComment;
            DG.DiemDG = iRating;
            DG.NgayCmt = DateTime.Parse(Ngay);
            TempData["MaSach"] = iMaSach;
            db.DanhGias.Add(DG);
            db.SaveChanges();
            List<DanhGia> LDG = db.DanhGias.Where(n => n.MaSach == iMaSach).ToList();
            double DGTB = 0;
            int DiemDG = 0;
            for(int i = 0;i < LDG.Count();i++)
            {
                DiemDG += int.Parse(DG.DiemDG.ToString());
            }
            DGTB = DiemDG / LDG.Count();
            return RedirectToAction("ChiTietSach","ViewSach");
        }
    }
}