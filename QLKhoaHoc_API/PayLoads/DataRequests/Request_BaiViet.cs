using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataRequests
{
    public class Request_BaiViet
    {
        public string TenBaiViet { get; set; }
        public string TenTacGia { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungNgan { get; set; }
        public string HinhAnh { get; set; }
        public int TaiKhoanId { get; set; }
    }
}
