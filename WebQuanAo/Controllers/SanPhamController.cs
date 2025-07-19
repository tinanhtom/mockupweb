using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model; 

namespace WebQuanAo.Controllers
{
    public class SanPhamController : Controller
    {
        WebShopDbContext db = new WebShopDbContext(); 
        // GET: SanPham
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }
        public PartialViewResult CategoryPartial()
        {
            var cateList = db.TheLoais.ToList();
            return PartialView(cateList);
        }
        public ActionResult TheLoai(string name)
        {
            if (name == null)
            {
                return View(db.TheLoais.ToList());
            }
            else
            {
                return View(db.TheLoais.Where(s => s.TenTheLoai.Contains(name)).ToList());
            }
         
        }
         public ActionResult SearchName(string searchString)
        {
            return View(db.SanPhams.Where(s => s.TenSanPham.Contains(searchString) || searchString == null).ToList());
        }


    }
}