using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("LoaiBaiViet_tbl")]
    public class LoaiBaiViet
    {
        public int Id { get; set; }
        public string? TenLoaiBaiViet { get; set; }
        public IEnumerable<ChuDe>? chuDes { get; set; }
    }
}
