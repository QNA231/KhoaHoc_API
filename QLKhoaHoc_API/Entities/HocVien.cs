using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("HocVien_tbl")]
    public class HocVien
    {
        public int Id { get; set; }
        public string? HinhAnh { get; set; }
        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public string? TinhThanh { get; set; }
        public string? QuanHuyen { get; set; }
        public string? PhuongXa { get; set; }
        public int? SoNha { get; set; }
        public IEnumerable<DangKyHoc>? dangKyHocs { get; set; }
    }
}
