using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bai20_TLTC.Models;

public partial class QuanlysinhvienContext : DbContext
{
    public QuanlysinhvienContext()
    {
    }

    public QuanlysinhvienContext(DbContextOptions<QuanlysinhvienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GiaoVien> GiaoViens { get; set; }

    public virtual DbSet<Lopsh> Lopshes { get; set; }

    public virtual DbSet<LshSv> LshSvs { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8E8BNI1;Initial Catalog=QUANLYSINHVIEN;User ID=sa;Password=123456789;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GiaoVien>(entity =>
        {
            entity.HasKey(e => e.MaGv).HasName("PK__GiaoVien__2725AEF3FAD083CE");

            entity.ToTable("GiaoVien");

            entity.Property(e => e.MaGv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaGV");
            entity.Property(e => e.AccRight)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ChucDanh).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(40);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.EmailDct)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EmailDCT");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HoTenGv)
                .HasMaxLength(40)
                .HasColumnName("HoTenGV");
            entity.Property(e => e.HocVi).HasMaxLength(10);
            entity.Property(e => e.MaDv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(10);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tel)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenViet).HasMaxLength(40);
            entity.Property(e => e.WebSite)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lopsh>(entity =>
        {
            entity.HasKey(e => e.MaLsh).HasName("PK__LOPSH__3B983FF67299EE29");

            entity.ToTable("LOPSH");

            entity.Property(e => e.MaLsh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaLSH");
            entity.Property(e => e.GhiChu).HasMaxLength(60);
            entity.Property(e => e.HeDaoTao).HasMaxLength(10);
            entity.Property(e => e.HkhienHanh).HasColumnName("HKHienHanh");
            entity.Property(e => e.MaBiThu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaGvcn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaGVCN");
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaLopPho)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaLopTruong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNganh)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Siso).HasColumnName("SISO");
            entity.Property(e => e.Slnam).HasColumnName("SLNam");
            entity.Property(e => e.Sltt).HasColumnName("SLTT");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenLsh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TenLSH");
        });

        modelBuilder.Entity<LshSv>(entity =>
        {
            entity.HasKey(e => new { e.MaLsh, e.MaSv }).HasName("PK__LSH_SV__89EA6F77E36C2C7A");

            entity.ToTable("LSH_SV");

            entity.Property(e => e.MaLsh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaLSH");
            entity.Property(e => e.MaSv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSV");
            entity.Property(e => e.Cn2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CN2");
            entity.Property(e => e.CurSem).HasColumnName("curSem");
            entity.Property(e => e.Ecp).HasColumnName("ECP");
            entity.Property(e => e.Gcp).HasColumnName("GCP");
            entity.Property(e => e.GhiChu).HasMaxLength(60);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PK__SINHVIEN__2725081AE9B7DAE9");

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.MaSv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSV");
            entity.Property(e => e.AccNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CapDt)
                .HasMaxLength(10)
                .HasColumnName("CapDT");
            entity.Property(e => e.Cdrth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CDRTH");
            entity.Property(e => e.Dantoc).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(40);
            entity.Property(e => e.DiemRl).HasColumnName("DiemRL");
            entity.Property(e => e.DiemTs).HasColumnName("DiemTS");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.EmailDct)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EmailDCT");
            entity.Property(e => e.GhiChu).HasMaxLength(60);
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ho).HasMaxLength(10);
            entity.Property(e => e.Ks)
                .HasMaxLength(10)
                .HasColumnName("KS");
            entity.Property(e => e.MaNh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNH");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NoiSinh).HasMaxLength(20);
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Qdtt)
                .HasMaxLength(10)
                .HasColumnName("QDTT");
            entity.Property(e => e.Scmnd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SCMND");
            entity.Property(e => e.ScmndImg)
                .HasMaxLength(10)
                .HasColumnName("SCMND_IMG");
            entity.Property(e => e.Specia).HasMaxLength(10);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Tel)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(30);
            entity.Property(e => e.TenKd)
                .HasMaxLength(10)
                .HasColumnName("TenKD");
            entity.Property(e => e.TenViet).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
