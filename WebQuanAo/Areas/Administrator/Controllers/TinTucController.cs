using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanAoNamNu1.Model;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace WebQuanAo.Areas.Administrator.Controllers
{
    public class TinTucController : Controller
    {
        webshop db = new webshop();
        // GET: Content
        public ActionResult Index()
        {
            return View(db.TinTucs.ToList());
        }

        // GET: Content/Details/5
        public ActionResult Details(string id)
        {
            return View(db.TinTucs.Where(s => s.ID_TT == id).FirstOrDefault());
        }
        //public ActionResult SelectCate()
        //{
        //    ca cate = new ProductCategory();
        //    //cate.ListCate = db.ProductCategories.ToList<ProductCategory>();
        //    return PartialView(cate);
        //}

        // GET: Content/Create
        //[Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            var role = Session["roleid"];
            if (role.ToString() != "1")
            {
                return Content("Bạn ko có quyền đăng nhập ");
            }
            else
            {
                TinTuc con = new TinTuc();
                return View();
            }
        }

        // POST: Content/Create
        // [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Create(TinTuc con)
        {
            try
            {
                // TODO: Add insert logic here
                if (con.ImageUpload != null)
                {
                    string file = Path.GetFileNameWithoutExtension(con.ImageUpload.FileName);
                    string extension = Path.GetExtension(con.ImageUpload.FileName);
                    file = file + extension;
                    con.Image = "/Content/images/" + file;
                    //pro.MoreImages= "~/Contents/images/" + file;
                    con.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), file));
                }
                db.TinTucs.Add(con);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }

        }

        // GET: Content/Edit/5
        //[Authorize(Roles = "Manager")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Content/Edit/5
        [HttpPost]
        // [Authorize(Roles = "Manager")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Content/Delete/5
        // [Authorize(Roles = "Manager")]
        public ActionResult Delete(string id)
        {
            var role = Session["roleid"];
            if (role.ToString() != "1")
            {
                return Content("Bạn ko có quyền đăng nhập ");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TinTuc s = db.TinTucs.Find(id);
                if (s == null)
                {
                    return HttpNotFound();
                }
                return View(s);
            }
        }

        // POST: Administrator/ChatLieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TinTuc s = db.TinTucs.Find(id);
            db.TinTucs.Remove(s);
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
