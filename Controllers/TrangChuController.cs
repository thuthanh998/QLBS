using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBooks.Models;

namespace OnlineBooks.Controllers
{
    public class TrangChuController : Controller
    {
        QuanLyBanSachEntities2 db = new QuanLyBanSachEntities2();
        // GET: TrangChu
        public ActionResult ViewTrangChu()
        {
            return View(db.Saches.ToList());
        }
    }
}