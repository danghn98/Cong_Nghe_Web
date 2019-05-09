namespace Web_Ban_Giay_2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int Makh { get; set; }

        [StringLength(50)]
        public string Tenkh { get; set; }

        [StringLength(30)]
        public string Taikhoan { get; set; }

        [StringLength(30)]
        public string Matkhau { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Gioitinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(50)]
        public string Sst { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
