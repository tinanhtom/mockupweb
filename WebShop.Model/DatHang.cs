namespace WebShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHang")]
    public partial class DatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatHang()
        {
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }

        [Key]
        [StringLength(10)]
        public string SoHoaDon { get; set; }

        public int? UserId { get; set; }

        [StringLength(10)]
        public string MaKhachHang { get; set; }

        [StringLength(100)]
        public string DiaChiKhachHang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayDatHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual USER USER { get; set; }

        
    }
}
