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
    public class ChiTietDatHangController : Controller
    {
        private WebShopDbContext db = new WebShopDbContext();

        // GET: Administrator/ChiTietDatHang
        public ActionResult Index(ChiTietDatHang ct)
        {
            
            var chiTietDatHangs = db.ChiTietDatHangs.Include(c => c.DatHang).Include(c => c.SanPham);
            return View(chiTietDatHangs.ToList());
        }

        // GET: Administrator/ChiTietDatHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            chiTietDatHang.ID = this.GuidId();//
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDatHang);
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
        // GET: Administrator/ChiTietDatHang/Create
        public ActionResult Create()
        {
            ViewBag.SoHoaDon = new SelectList(db.DatHangs, "SoHoaDon", "MaKhachHang");
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: Administrator/ChiTietDatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaSanPham,SoHoaDon,SoLuong,DonGia,ThanhTien")] ChiTietDatHang chiTietDatHang)
        {
            if (ModelState.IsValid)
            {
                chiTietDatHang.ID = this.GuidId();//
                db.ChiTietDatHangs.Add(chiTietDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SoHoaDon = new SelectList(db.DatHangs, "SoHoaDon", "MaKhachHang", chiTietDatHang.SoHoaDon);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
            return View(chiTietDatHang);
        }

        // GET: Administrator/ChiTietDatHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            chiTietDatHang.ID = this.GuidId();//
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoHoaDon = new SelectList(db.DatHangs, "SoHoaDon", "MaKhachHang", chiTietDatHang.SoHoaDon);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
            return View(chiTietDatHang);
        }

        // POST: Administrator/ChiTietDatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaSanPham,SoHoaDon,SoLuong,DonGia,ThanhTien")] ChiTietDatHang chiTietDatHang)
        {
            if (ModelState.IsValid)
            {
                chiTietDatHang.ID = this.GuidId();//
                db.Entry(chiTietDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SoHoaDon = new SelectList(db.DatHangs, "SoHoaDon", "MaKhachHang", chiTietDatHang.SoHoaDon);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
            return View(chiTietDatHang);
        }

        // GET: Administrator/ChiTietDatHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            chiTietDatHang.ID = this.GuidId();//
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDatHang);
        }

        // POST: Administrator/ChiTietDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            chiTietDatHang.ID = this.GuidId();//
            db.ChiTietDatHangs.Remove(chiTietDatHang);
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
    }
}
