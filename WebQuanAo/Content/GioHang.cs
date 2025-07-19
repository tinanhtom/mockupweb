using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Model;

namespace WebQuanAo.Content
{
    public class GioHangItem
    {
        public SanPham sp { get; set; }
        public int SoLuong { get; set; }
    }
    public class GioHang
    {
        List<GioHangItem> items = new List<GioHangItem>();
        public IEnumerable<GioHangItem> Items
        {
            get { return items; }
        }
        public void ThemSPVaoGioHang(SanPham sp, int sl = 1)
        {
            var item = Items.FirstOrDefault(s => s.sp.MaSanPham == sp.MaSanPham);
            if (item == null)
                items.Add(new GioHangItem
                {
                    sp = sp,



                    SoLuong = sl
                });
            else
            {
                item.SoLuong += sl;
            }
        }
        public int TongSP()
        {
            return items.Sum(s => s.SoLuong);
        }
        public decimal TongTien()
        {
            var total = items.Sum(s => s.SoLuong * s.sp.DonGia);
            return (decimal)total;
        }
        public void update_sp(string id, int new_sp)
        {
            var itm = items.Find(s => s.sp.MaSanPham == id);
            if (itm != null)
            {
                itm.SoLuong = new_sp;
            }
        }
        public void XoaSP(string id)
        {
            items.RemoveAll(s => s.sp.MaSanPham == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}