using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("LoaiKhoaHoc_tbl")]
    public class LoaiKhoaHoc
    {
        public int Id { get; set; }
        public string? TenLoaiKhoaHoc { get; set; }
        public IEnumerable<KhoaHoc>? khoaHocs { get; set; }
    }
}
