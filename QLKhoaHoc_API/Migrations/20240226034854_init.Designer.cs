﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLKhoaHoc_API.DataContext;

#nullable disable

namespace QLKhoaHocAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240226034854_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLKhoaHoc_API.Entities.BaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChuDeId")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDungNgan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<string>("TenBaiViet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTacGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChuDeId");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("BaiViet_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.ChuDe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LoaiBaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoaiBaiVietId");

                    b.ToTable("ChuDe_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.DangKyHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HocVIenId")
                        .HasColumnType("int");

                    b.Property<int>("KhoaHocId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<int>("TinhTrangHocId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HocVIenId");

                    b.HasIndex("KhoaHocId");

                    b.HasIndex("TaiKhoanId");

                    b.HasIndex("TinhTrangHocId");

                    b.ToTable("DangKyHoc_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.HocVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongXa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuanHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoNha")
                        .HasColumnType("int");

                    b.Property<string>("TinhThanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HocVien_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.KhoaHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GioiThieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HocPhi")
                        .HasColumnType("float");

                    b.Property<int>("LoaiKhoaHocId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoHocVien")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongMon")
                        .HasColumnType("int");

                    b.Property<string>("TenKhoaHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThoiGianHoc")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiKhoaHocId");

                    b.ToTable("KhoaHoc_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.LoaiBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenLoaiBaiViet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiBaiViet_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.LoaiKhoaHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenLoaiKhoaHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiKhoaHoc_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.QuyenHan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenQuyenHan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuyenHan_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenHanId")
                        .HasColumnType("int");

                    b.Property<string>("TajKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuyenHanId");

                    b.ToTable("TaiKhoan_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.TinhTrangHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenTinhTrang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TinhTrangHoc_tbl");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.BaiViet", b =>
                {
                    b.HasOne("QLKhoaHoc_API.Entities.ChuDe", "ChuDe")
                        .WithMany()
                        .HasForeignKey("ChuDeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLKhoaHoc_API.Entities.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("TaiKhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChuDe");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.ChuDe", b =>
                {
                    b.HasOne("QLKhoaHoc_API.Entities.LoaiBaiViet", "LoaiBaiViet")
                        .WithMany()
                        .HasForeignKey("LoaiBaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiBaiViet");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.DangKyHoc", b =>
                {
                    b.HasOne("QLKhoaHoc_API.Entities.HocVien", "HocVien")
                        .WithMany()
                        .HasForeignKey("HocVIenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLKhoaHoc_API.Entities.KhoaHoc", "KhoaHoc")
                        .WithMany()
                        .HasForeignKey("KhoaHocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLKhoaHoc_API.Entities.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("TaiKhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLKhoaHoc_API.Entities.TinhTrangHoc", "TinhTrangHoc")
                        .WithMany()
                        .HasForeignKey("TinhTrangHocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HocVien");

                    b.Navigation("KhoaHoc");

                    b.Navigation("TaiKhoan");

                    b.Navigation("TinhTrangHoc");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.KhoaHoc", b =>
                {
                    b.HasOne("QLKhoaHoc_API.Entities.LoaiKhoaHoc", "LoaiKhoaHoc")
                        .WithMany()
                        .HasForeignKey("LoaiKhoaHocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiKhoaHoc");
                });

            modelBuilder.Entity("QLKhoaHoc_API.Entities.TaiKhoan", b =>
                {
                    b.HasOne("QLKhoaHoc_API.Entities.QuyenHan", "QuyenHan")
                        .WithMany()
                        .HasForeignKey("QuyenHanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuyenHan");
                });
#pragma warning restore 612, 618
        }
    }
}
