using System.ComponentModel.DataAnnotations.Schema;

namespace QLKhoaHoc_API.Entities
{
    [Table("RefreshToken_tbl")]
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredTime { get; set; }
        public int TaiKhoanId { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
