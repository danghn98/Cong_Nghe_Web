namespace Web_Ban_Giay_2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int Matk { get; set; }

        [StringLength(50)]
        public string Tentk { get; set; }

        [StringLength(50)]
        public string Matkhau { get; set; }
    }
}
