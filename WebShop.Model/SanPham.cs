namespace WebShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(10)]
        public string MaDoiTuong { get; set; }

        [StringLength(10)]
        public string MaTheLoai { get; set; }

        [StringLength(10)]
        public string MaKichCo { get; set; }

        [StringLength(10)]
        public string MaChatLieu { get; set; }

        [StringLength(10)]
        public string MaNhaSanXuat { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongBan { get; set; }

        public double? DonGia { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapNhat { get; set; }

        [StringLength(50)]
        public string HinhMinhHoa { get; set; }

        public virtual ChatLieu ChatLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }

        public virtual DoiTuong DoiTuong { get; set; }

        public virtual KichCo KichCo { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }

        public virtual TheLoai TheLoai { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}
