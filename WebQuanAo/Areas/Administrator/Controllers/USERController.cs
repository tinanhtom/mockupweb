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
    public class USERController : Controller
    {
        private WebShopDbContext db = new WebShopDbContext();

        // GET: Administrator/USER
        public ActionResult Index()
        {
            return View(db.USERS.ToList());
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
        // GET: Administrator/USER/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
<<<<<<< Updated upstream
            USER uSER = db.USERS.Find(id);
=======
            NhanVien uSER = db.NhanViens.Find(id);
            uSER.MaNhanVien = this.GuidId();//
>>>>>>> Stashed changes
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // GET: Administrator/USER/Create
        public ActionResult Create()
        {
            var role = Session["roleid"];
            if (role.ToString() != "1")
            {
                return Content("Bạn ko có quyền đăng nhập ");
            }
            else
            {
                NhanVien n = new NhanVien();
                n.MaNhanVien = this.GuidId();//
                ViewBag.ID_Role = new SelectList(db.Roles, "ID_Role", "RoleName");
                return View(n);
            }
            
        }

        // POST: Administrator/USER/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< Updated upstream
        public ActionResult Create([Bind(Include = "UserId,UserName,PassWord,Email,Phone,Allowed")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.USERS.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
=======
        public ActionResult Create(NhanVien uSER)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    uSER.MaNhanVien = this.GuidId();//
                    db.NhanViens.Add(uSER);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View();
                }
>>>>>>> Stashed changes
            }
            ViewBag.ID_Role = new SelectList(db.Roles, "ID_Role", "RoleName", uSER.ID_Role);
            return View(uSER);
        }

        // GET: Administrator/USER/Edit/5
        public ActionResult Edit(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
<<<<<<< Updated upstream
            USER uSER = db.USERS.Find(id);
=======
            NhanVien uSER = db.NhanViens.Find(id);
            uSER.MaNhanVien = this.GuidId();//
>>>>>>> Stashed changes
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // POST: Administrator/USER/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,PassWord,Email,Phone,Allowed")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                uSER.MaNhanVien = this.GuidId();//
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Role = new SelectList(db.Users, "ID_Role", "RoleName", uSER.ID_Role);
            return View(uSER);
        }

        // GET: Administrator/USER/Delete/5
        public ActionResult Delete(string id)
        {
            var role = Session["roleid"];
            if (role.ToString() != "1")
            {
                return Content("Bạn ko có quyền đăng nhập ");
            }
<<<<<<< Updated upstream
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
=======
            else
>>>>>>> Stashed changes
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                NhanVien uSER = db.NhanViens.Find(id);
                uSER.MaNhanVien = this.GuidId();//
                if (uSER == null)
                {
                    return HttpNotFound();
                }
                return View(uSER);
            }
        }

        // POST: Administrator/USER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
<<<<<<< Updated upstream
            USER uSER = db.USERS.Find(id);
            db.USERS.Remove(uSER);
=======
            NhanVien uSER = db.NhanViens.Find(id);
            uSER.MaNhanVien = this.GuidId();//
            db.NhanViens.Remove(uSER);
>>>>>>> Stashed changes
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
