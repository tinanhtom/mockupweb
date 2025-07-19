namespace WebShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatHang")]
    public partial class ChiTietDatHang
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(10)]
        public string MaSanPham { get; set; }

        [StringLength(10)]
        public string SoHoaDon { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual DatHang DatHang { get; set; }

        public double Total
        {
            get
            {
                if (this.SoLuong != null && this.DonGia != null)
                {
                    return (double)(this.SoLuong * this.DonGia);
                }
                return 0;
            }
        }
    }
}
