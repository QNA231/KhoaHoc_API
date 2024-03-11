using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("QuyenHan_tbl")]
    public class QuyenHan
    {
        public int Id { get; set; }
        public string? TenQuyenHan { get; set; }
        public IEnumerable<TaiKhoan>? taiKhoans { get; set; }
    }
}
