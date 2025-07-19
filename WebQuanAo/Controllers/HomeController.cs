using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;

namespace WebQuanAo.Controllers
{
    public class HomeController : Controller
    {
        WebShopDbContext db = new WebShopDbContext();
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(4).ToList();
            ViewBag.SanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(4).ToList();
            return View();
        }
        public ActionResult SanPhamBanChay()
        {
            ViewBag.TrangSanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(10000).ToList();
            return View();
        }

        public ActionResult SanPhamMoi()
        {
            ViewBag.TrangSanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(10000).ToList();
            return View();
        }
        public ActionResult Detailes(string id)
        {
            //Tìm sản phẩm có mã sản phẩm = id
            SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSanPham == id);
            //Nếu không tìm thấy
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult News()
        {
            return View(db.TinTucs.ToList());
        }
        public string GuidId()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        public ActionResult Feedback(FormCollection form)
        {
            Feedback fb = new Feedback();
            fb.IDfeedback = this.GuidId();
            fb.Name = form["NameFeedback"];
            fb.Mail = form["MailFeedback"];
            fb.Description = form["Motafeedback"];
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return RedirectToAction("Feedback_Success", "Home");
        }
        public ActionResult Feedback_Success()
        {
            return View();
        }
    }
}