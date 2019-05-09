namespace Web_Ban_Giay_2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mau")]
    public partial class Mau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mau()
        {
            ChiTietMaus = new HashSet<ChiTietMau>();
        }

        [Key]
        public int Mamau { get; set; }

        [StringLength(50)]
        public string Tenmau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietMau> ChiTietMaus { get; set; }
    }
}
