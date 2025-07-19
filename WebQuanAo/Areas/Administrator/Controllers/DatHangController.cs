using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;

namespace WebQuanAo.Areas.Administrator.Controllers
{
    public class DatHangController : Controller
    {
        private WebShopDbContext db = new WebShopDbContext();

        // GET: Administrator/DatHang
        public ActionResult Index()
        {
            var datHangs = db.DatHangs.Include(d => d.KhachHang);
            return View(datHangs.ToList());
        }

        // GET: Administrator/DatHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHang datHang = db.DatHangs.Find(id);
            datHang.SoHoaDon = this.GuidId();//
            if (datHang == null)
            {
                return HttpNotFound();
            }
            return View(datHang);
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
        // GET: Administrator/DatHang/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang");
            return View();
        }

        // POST: Administrator/DatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoHoaDon,MaKhachHang,DiaChiKhachHang,NgayDatHang")] DatHang datHang)
        {
            if (ModelState.IsValid)
            {
                datHang.SoHoaDon = this.GuidId();//
                db.DatHangs.Add(datHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", datHang.MaKhachHang);
            return View(datHang);
        }

        // GET: Administrator/DatHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHang datHang = db.DatHangs.Find(id);
            datHang.SoHoaDon = this.GuidId();//
            if (datHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", datHang.MaKhachHang);
            return View(datHang);
        }

        // POST: Administrator/DatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoHoaDon,MaKhachHang,DiaChiKhachHang,NgayDatHang")] DatHang datHang)
        {
            if (ModelState.IsValid)
            {
                datHang.SoHoaDon = this.GuidId();//
                db.Entry(datHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", datHang.MaKhachHang);
            return View(datHang);
        }

        // GET: Administrator/DatHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHang datHang = db.DatHangs.Find(id);
            datHang.SoHoaDon = this.GuidId();//
            if (datHang == null)
            {
                return HttpNotFound();
            }
            return View(datHang);
        }

        // POST: Administrator/DatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
           
            DatHang datHang = db.DatHangs.Find(id);
            datHang.SoHoaDon = this.GuidId();//
            db.DatHangs.Remove(datHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult More(string id)
        {
            Session["Details"] = db.DatHangs.Where(d => d.SoHoaDon == id).FirstOrDefault();
            return RedirectToRoute(new { controller = "DatHang", action = "Index", id = 0 });
        }
    }
}
