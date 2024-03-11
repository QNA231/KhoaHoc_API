using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("TaiKhoan_tbl")]
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string? TenNguoiDung { get; set; }
        public string? TajKhoan { get; set; }
        public string? MatKhau { get; set; }
        public int? QuyenHanId { get; set; }
        public QuyenHan? QuyenHan { get; set; }
        public IEnumerable<BaiViet>? baiViets { get; set; }
        public IEnumerable<DangKyHoc>? dangKyHocs { get; set; }
    }
}
