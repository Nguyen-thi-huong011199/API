using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doan5.Models
{
    public partial class Doan5Context : DbContext
    {
        //public Doan5Context()
        //{
        //}

        public Doan5Context(DbContextOptions<Doan5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Hoso> Hoso { get; set; }
        public virtual DbSet<Khuvuc> Khuvuc { get; set; }
        public virtual DbSet<Loaicongviec> Loaicongviec { get; set; }
        public virtual DbSet<Nguoitimviec> Nguoitimviec { get; set; }
        public virtual DbSet<Nhatuyendung> Nhatuyendung { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<UserNd> UserNd { get; set; }
        public virtual DbSet<Vieclam> Vieclam { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-37GHBAQ\\SQLEXPRESS;Database=Doan5;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hoso>(entity =>
            {
                entity.HasKey(e => e.MaHs)
                    .HasName("PK__Hoso__2725A6EF59D0FE11");

                entity.Property(e => e.MaHs)
                    .HasColumnName("MaHS");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileHs)
                    .IsRequired()
                    .HasColumnName("FileHS")
                    .HasMaxLength(50);

                entity.Property(e => e.MaCv).HasColumnName("MaCV");

                entity.Property(e => e.MaKv).HasColumnName("MaKV");

                entity.Property(e => e.Trangthai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.Hoso)
                    .HasForeignKey(d => d.MaCv)
                    .HasConstraintName("FR_vieclam_hoso");

                entity.HasOne(d => d.MaKvNavigation)
                    .WithMany(p => p.Hoso)
                    .HasForeignKey(d => d.MaKv)
                    .HasConstraintName("FR_khuvuc_hoso");

                entity.HasOne(d => d.MauserNavigation)
                    .WithMany(p => p.Hoso)
                    .HasForeignKey(d => d.Mauser)
                    .HasConstraintName("FR_UserND_hoso");
            });

            modelBuilder.Entity<Khuvuc>(entity =>
            {
                entity.HasKey(e => e.MaKv)
                    .HasName("PK__Khuvuc__2725CF6CDC41C406");

                entity.Property(e => e.MaKv)
                    .HasColumnName("MaKV");

                entity.Property(e => e.TenKv)
                    .IsRequired()
                    .HasColumnName("TenKV")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Loaicongviec>(entity =>
            {
                entity.HasKey(e => e.MaloaiCv)
                    .HasName("PK__Loaicong__F82E4CF1E8769AAE");

                entity.Property(e => e.MaloaiCv)
                    .HasColumnName("MaloaiCV");

                entity.Property(e => e.TenloaiCv)
                    .IsRequired()
                    .HasColumnName("TenloaiCV")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nguoitimviec>(entity =>
            {
                entity.HasKey(e => e.MaNtv)
                    .HasName("PK__Nguoitim__3A1BD3F7F5E051D9");

                entity.Property(e => e.MaNtv)
                    .HasColumnName("MaNTV");

                entity.Property(e => e.TenNtv)
                    .IsRequired()
                    .HasColumnName("TenNTV")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MauserNavigation)
                    .WithMany(p => p.Nguoitimviec)
                    .HasForeignKey(d => d.Mauser)
                    .HasConstraintName("FR_usernd_nguoitinviec");
            });

            modelBuilder.Entity<Nhatuyendung>(entity =>
            {
                entity.HasKey(e => e.MaNtd)
                    .HasName("PK__Nhatuyen__3A1BD385F4FE83D1");

                entity.Property(e => e.MaNtd)
                    .HasColumnName("MaNTD");

                entity.Property(e => e.TenNtd)
                    .IsRequired()
                    .HasColumnName("TenNTD")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MauserNavigation)
                    .WithMany(p => p.Nhatuyendung)
                    .HasForeignKey(d => d.Mauser)
                    .HasConstraintName("FR_usernd_nhatuyendung");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.MaTk)
                    .HasName("PK__Taikhoan__27250070A312C4D6");

                entity.Property(e => e.MaTk)
                    .HasColumnName("MaTK");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phanquyen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TenTk)
                    .IsRequired()
                    .HasColumnName("TenTK")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MauserNavigation)
                    .WithMany(p => p.Taikhoan)
                    .HasForeignKey(d => d.Mauser)
                    .HasConstraintName("FR_usernd_taikhoan");
            });

            modelBuilder.Entity<UserNd>(entity =>
            {
                entity.HasKey(e => e.Mauser)
                    .HasName("PK__UserND__4FB8460CD5A083F2");

                entity.ToTable("UserND");

                entity.Property(e => e.Mauser)
                    .HasColumnName("Mauser");

                entity.Property(e => e.Anhdaidien)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Noilamviec)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tenuser)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vieclam>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__Vieclam__27258E76EE975FE2");

                entity.Property(e => e.MaCv)
                    .HasColumnName("MaCV");

                entity.Property(e => e.Anh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Luotxem)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaKv).HasColumnName("MaKV");

                entity.Property(e => e.MaNtd).HasColumnName("MaNTD");

                entity.Property(e => e.MaloaiCv).HasColumnName("MaloaiCV");

                entity.Property(e => e.MotaCv)
                    .IsRequired()
                    .HasColumnName("MotaCV")
                    .HasMaxLength(300);

                entity.Property(e => e.Mucluong)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Ngaydang).HasColumnType("date");

                entity.Property(e => e.TenCv)
                    .IsRequired()
                    .HasColumnName("TenCV")
                    .HasMaxLength(50);

                entity.Property(e => e.Tencongty)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaKvNavigation)
                    .WithMany(p => p.Vieclam)
                    .HasForeignKey(d => d.MaKv)
                    .HasConstraintName("FR_khuvuc_vieclam");

                entity.HasOne(d => d.MaNtdNavigation)
                    .WithMany(p => p.Vieclam)
                    .HasForeignKey(d => d.MaNtd)
                    .HasConstraintName("FR_nhatuyendung_vieclam");

                entity.HasOne(d => d.MaloaiCvNavigation)
                    .WithMany(p => p.Vieclam)
                    .HasForeignKey(d => d.MaloaiCv)
                    .HasConstraintName("FR_loaicongviec_vieclam");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
