using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("ChuDe_tbl")]
    public class ChuDe
    {
        public int Id { get; set; }
        public string? TenChuDe { get; set; }
        public string? NoiDung { get; set; }
        public int? LoaiBaiVietId { get; set; }
        public LoaiBaiViet? LoaiBaiViet { get; set; }
        public IEnumerable<BaiViet>? baiViets { get; set; }
    }
}
