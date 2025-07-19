using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;

namespace WebQuanAo.Controllers
{
    public class ShoppingCartController : Controller
    {
        WebShopDbContext db = new WebShopDbContext();
        // GET: ShoppingCart
        public ActionResult Showcart()
        {
            if (Session["Content.GioHang"] == null)
                return View("EmptyCart");
            Content.GioHang gh = Session["Content.GioHang"] as Content.GioHang;
            return View(gh);
        }
        //Tao moi gio hang
        public Content.GioHang GetGioHang()
        {
            Content.GioHang gh = Session["Content.GioHang"] as Content.GioHang;
            if (gh == null || Session["Content.GioHang"] == null)
            {
                gh = new Content.GioHang();
                Session["Content.GioHang"] = gh;
            }
            return gh;
        }
        //them sp vao gio hang
        public ActionResult addtocart(string id)
        {
            var pro = db.SanPhams.SingleOrDefault(s => s.MaSanPham == id);
            if (pro != null)
            {
                GetGioHang().ThemSPVaoGioHang(pro);
            }
            return RedirectToAction("Showcart", "ShoppingCart");
        }
        //update gio hang
        public ActionResult Update_Cart_Qua(FormCollection form)
        {
            Content.GioHang cart = Session["Content.GioHang"] as Content.GioHang;
            string id = (form["IDPro"]);
            int qua = int.Parse(form["QualityPro"]);
            cart.update_sp(id, qua);
            return RedirectToAction("Showcart", "ShoppingCart");
        }
        //xoa gio hang
        public ActionResult Remove(string id)
        {
            Content.GioHang cart = Session["Content.GioHang"] as Content.GioHang;
            cart.XoaSP(id);
            return RedirectToAction("Showcart", "ShoppingCart");

        }
        public PartialViewResult BagCart()
        {
            int total_quality = 0;
            Content.GioHang cart = Session["Content.GioHang"] as Content.GioHang;
            if (cart != null)
            {
                total_quality = cart.TongSP();

            }
            ViewBag.QuantityCart = total_quality;
            return PartialView("BagCart");
        }
        public ActionResult FormTTKH()
        {
            return View();
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

        public ActionResult CheckOut(FormCollection form)
        {
            try
            { 
            Content.GioHang cart = Session["Content.GioHang"] as Content.GioHang;
            // Khach hang moi
            /* IDEA
             * Tạo 1 hàm, trong đó đầu vào là 1 chuỗi cũ (gọi là chuỗi x)
             * (VD: KH0001 -> Lấy từ db.TAIKHOAN.FindLast)
             * x.Subtring (0,2) -> chuỗi tĩnh
             * convert.ToInt(x.substring(2,last) -> số i cũ
             * Tăng i++
             * Convert i mới sang chuỗi 4 ký tự
             * kết quả= chuỗi tỉnh + chuỗi i
             */
            KhachHang kh = new KhachHang();
            kh.TenDangNhap = "NguyenVanA";
            kh.MatKhau = "123456";
            kh.MaKhachHang = this.GuidId();//
            kh.NgaySinh = DateTime.Now;

            kh.TenKhachHang = form["TenKhachHang"];
            kh.DienThoaiKhach = form["DienThoaiKhach"];
            kh.Email = form["Email"];
            DatHang order = new DatHang();
            order.MaKhachHang = kh.MaKhachHang;
            db.KhachHangs.Add(kh);

            order.SoHoaDon = this.GuidId();//
            order.DiaChiKhachHang = form["DiaChiKhachHang"];
            order.NgayDatHang = DateTime.Now;
            db.DatHangs.Add(order);

            foreach (var item in cart.Items)
            {

                ChiTietDatHang order_detail = new ChiTietDatHang();
                //order_detail.ID = i.ToString();
                order_detail.SoHoaDon = order.SoHoaDon;
                order_detail.MaSanPham = item.sp.MaSanPham;
                order_detail.ID = this.GuidId();
                order_detail.DonGia = (int)item.sp.DonGia;
                order_detail.SoLuong = item.SoLuong;
                db.ChiTietDatHangs.Add(order_detail);


            }

            db.SaveChanges();
            cart.ClearCart();

            return RedirectToAction("Check_out_success", "ShoppingCart");
        }
            catch(Exception e)
            {
                return Content("Error checkout. Please check information customer...");
            }
            
            
        }
        public ActionResult Check_out_success()
        {
            return View();
        }
    }
}