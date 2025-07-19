using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanAoNamNu1.Model;

namespace WebQuanAo.Areas.Administrator.Controllers
{
    public class FeedbackController : Controller
    {
        webshop db = new webshop();
        // GET: Administrator/Feedback
        public ActionResult Index()
        {
            return View(db.Feedbacks.ToList());
        }
    }
}