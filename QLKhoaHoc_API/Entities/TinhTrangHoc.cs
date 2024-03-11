using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("TinhTrangHoc_tbl")]
    public class TinhTrangHoc
    {
        public int Id { get; set; }
        public string? TenTinhTrang { get; set; }
        public IEnumerable<DangKyHoc>? dangKyHocs { get; set; }
    }
}
