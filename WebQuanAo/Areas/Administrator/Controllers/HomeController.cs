using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;

namespace WebQuanAo.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administrator/Home
        WebShopDbContext db = new WebShopDbContext();
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(string username, string password)
        {
            USER user = db.USERS.SingleOrDefault(x => x.UserName == username && x.PassWord == password && x.Allowed == 1);
            if (user != null)
            {
<<<<<<< Updated upstream
                Session["userid"] = user.UserId;
                Session["username"] = user.UserName;
=======
                Session["roleid"] = user.ID_Role;
                Session["userid"] = user.MaNhanVien;
                Session["username"] = user.TenNhanVien;
>>>>>>> Stashed changes
                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}
