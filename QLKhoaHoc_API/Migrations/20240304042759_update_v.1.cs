using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLKhoaHocAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_tbl_ChuDe_tbl_ChuDeId",
                table: "BaiViet_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "BaiViet_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuDe_tbl_LoaiBaiViet_tbl_LoaiBaiVietId",
                table: "ChuDe_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_HocVien_tbl_HocVIenId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_KhoaHoc_tbl_KhoaHocId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_TinhTrangHoc_tbl_TinhTrangHocId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_tbl_LoaiKhoaHoc_tbl_LoaiKhoaHocId",
                table: "KhoaHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_tbl_QuyenHan_tbl_QuyenHanId",
                table: "TaiKhoan_tbl");

            migrationBuilder.AlterColumn<string>(
                name: "TenTinhTrang",
                table: "TinhTrangHoc_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenNguoiDung",
                table: "TaiKhoan_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TajKhoan",
                table: "TaiKhoan_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "QuyenHanId",
                table: "TaiKhoan_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MatKhau",
                table: "TaiKhoan_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenQuyenHan",
                table: "QuyenHan_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiKhoaHoc",
                table: "LoaiKhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiBaiViet",
                table: "LoaiBaiViet_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianHoc",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TenKhoaHoc",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongMon",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SoHocVien",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiKhoaHocId",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "HocPhi",
                table: "KhoaHoc_tbl",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GioiThieu",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TinhThanh",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SoNha",
                table: "HocVien_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "QuanHuyen",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhuongXa",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "HocVien_tbl",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "DangKyHoc_tbl",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHoc_tbl",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "DangKyHoc_tbl",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "KhoaHocId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HocVIenId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TenChuDe",
                table: "ChuDe_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "ChuDe_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiBaiVietId",
                table: "ChuDe_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianTao",
                table: "BaiViet_tbl",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TenTacGia",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenBaiViet",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "BaiViet_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDungNgan",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ChuDeId",
                table: "BaiViet_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "RefreshToken_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_tbl_TaiKhoan_tbl_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_tbl_TaiKhoanId",
                table: "RefreshToken_tbl",
                column: "TaiKhoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_tbl_ChuDe_tbl_ChuDeId",
                table: "BaiViet_tbl",
                column: "ChuDeId",
                principalTable: "ChuDe_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "BaiViet_tbl",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuDe_tbl_LoaiBaiViet_tbl_LoaiBaiVietId",
                table: "ChuDe_tbl",
                column: "LoaiBaiVietId",
                principalTable: "LoaiBaiViet_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_HocVien_tbl_HocVIenId",
                table: "DangKyHoc_tbl",
                column: "HocVIenId",
                principalTable: "HocVien_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_KhoaHoc_tbl_KhoaHocId",
                table: "DangKyHoc_tbl",
                column: "KhoaHocId",
                principalTable: "KhoaHoc_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "DangKyHoc_tbl",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_TinhTrangHoc_tbl_TinhTrangHocId",
                table: "DangKyHoc_tbl",
                column: "TinhTrangHocId",
                principalTable: "TinhTrangHoc_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_tbl_LoaiKhoaHoc_tbl_LoaiKhoaHocId",
                table: "KhoaHoc_tbl",
                column: "LoaiKhoaHocId",
                principalTable: "LoaiKhoaHoc_tbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_tbl_QuyenHan_tbl_QuyenHanId",
                table: "TaiKhoan_tbl",
                column: "QuyenHanId",
                principalTable: "QuyenHan_tbl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_tbl_ChuDe_tbl_ChuDeId",
                table: "BaiViet_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "BaiViet_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuDe_tbl_LoaiBaiViet_tbl_LoaiBaiVietId",
                table: "ChuDe_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_HocVien_tbl_HocVIenId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_KhoaHoc_tbl_KhoaHocId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_tbl_TinhTrangHoc_tbl_TinhTrangHocId",
                table: "DangKyHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_tbl_LoaiKhoaHoc_tbl_LoaiKhoaHocId",
                table: "KhoaHoc_tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_tbl_QuyenHan_tbl_QuyenHanId",
                table: "TaiKhoan_tbl");

            migrationBuilder.DropTable(
                name: "RefreshToken_tbl");

            migrationBuilder.AlterColumn<string>(
                name: "TenTinhTrang",
                table: "TinhTrangHoc_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNguoiDung",
                table: "TaiKhoan_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TajKhoan",
                table: "TaiKhoan_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuyenHanId",
                table: "TaiKhoan_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MatKhau",
                table: "TaiKhoan_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenQuyenHan",
                table: "QuyenHan_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiKhoaHoc",
                table: "LoaiKhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiBaiViet",
                table: "LoaiBaiViet_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianHoc",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenKhoaHoc",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongMon",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoHocVien",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiKhoaHocId",
                table: "KhoaHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HocPhi",
                table: "KhoaHoc_tbl",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GioiThieu",
                table: "KhoaHoc_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TinhThanh",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoNha",
                table: "HocVien_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuanHuyen",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhuongXa",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "HocVien_tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HocVien_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "DangKyHoc_tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHoc_tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "DangKyHoc_tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhoaHocId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HocVIenId",
                table: "DangKyHoc_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenChuDe",
                table: "ChuDe_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "ChuDe_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiBaiVietId",
                table: "ChuDe_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianTao",
                table: "BaiViet_tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenTacGia",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenBaiViet",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "BaiViet_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDungNgan",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "BaiViet_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChuDeId",
                table: "BaiViet_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_tbl_ChuDe_tbl_ChuDeId",
                table: "BaiViet_tbl",
                column: "ChuDeId",
                principalTable: "ChuDe_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "BaiViet_tbl",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChuDe_tbl_LoaiBaiViet_tbl_LoaiBaiVietId",
                table: "ChuDe_tbl",
                column: "LoaiBaiVietId",
                principalTable: "LoaiBaiViet_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_HocVien_tbl_HocVIenId",
                table: "DangKyHoc_tbl",
                column: "HocVIenId",
                principalTable: "HocVien_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_KhoaHoc_tbl_KhoaHocId",
                table: "DangKyHoc_tbl",
                column: "KhoaHocId",
                principalTable: "KhoaHoc_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_TaiKhoan_tbl_TaiKhoanId",
                table: "DangKyHoc_tbl",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_tbl_TinhTrangHoc_tbl_TinhTrangHocId",
                table: "DangKyHoc_tbl",
                column: "TinhTrangHocId",
                principalTable: "TinhTrangHoc_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_tbl_LoaiKhoaHoc_tbl_LoaiKhoaHocId",
                table: "KhoaHoc_tbl",
                column: "LoaiKhoaHocId",
                principalTable: "LoaiKhoaHoc_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_tbl_QuyenHan_tbl_QuyenHanId",
                table: "TaiKhoan_tbl",
                column: "QuyenHanId",
                principalTable: "QuyenHan_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
