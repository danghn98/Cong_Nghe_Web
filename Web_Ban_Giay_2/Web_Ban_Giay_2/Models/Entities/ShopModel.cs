namespace Web_Ban_Giay_2.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopModel : DbContext
    {
        public ShopModel()
            : base("name=ShopModel8")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietMau> ChiTietMaus { get; set; }
        public virtual DbSet<ChiTietSize> ChiTietSizes { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Giay> Giays { get; set; }
        public virtual DbSet<LoaiGiay> LoaiGiays { get; set; }
        public virtual DbSet<Mau> Maus { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.Giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Giay>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.Giay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Giay>()
                .HasMany(e => e.ChiTietMaus)
                .WithRequired(e => e.Giay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Giay>()
                .HasMany(e => e.ChiTietSizes)
                .WithRequired(e => e.Giay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mau>()
                .HasMany(e => e.ChiTietMaus)
                .WithRequired(e => e.Mau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.ChiTietSizes)
                .WithRequired(e => e.Size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Tentk)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);
        }
    }
}
