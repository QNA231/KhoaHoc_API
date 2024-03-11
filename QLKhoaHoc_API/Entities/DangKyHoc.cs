using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("DangKyHoc_tbl")]
    public class DangKyHoc
    {
        public int Id { get; set; }
        public int? KhoaHocId { get; set; }
        public int? HocVIenId { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? TinhTrangHocId { get; set; }
        public int? TaiKhoanId { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        public HocVien? HocVien { get; set; }
        public TinhTrangHoc? TinhTrangHoc { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }
    }
}
