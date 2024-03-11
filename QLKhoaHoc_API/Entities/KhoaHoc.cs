using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("KhoaHoc_tbl")]
    public class KhoaHoc
    {
        public int Id { get; set; }
        public string? TenKhoaHoc { get; set; }
        public int? ThoiGianHoc { get; set; }
        public string? GioiThieu { get; set; }
        public string? NoiDung { get; set; }
        public double? HocPhi { get; set; }
        public int? SoHocVien { get; set; }
        public int? SoLuongMon { get; set; }
        public string? HinhAnh { get; set; }
        public int? LoaiKhoaHocId { get; set; }
        public LoaiKhoaHoc? LoaiKhoaHoc { get; set; }
        public IEnumerable<DangKyHoc>? dangKyHocs { get; set; }
    }
}
