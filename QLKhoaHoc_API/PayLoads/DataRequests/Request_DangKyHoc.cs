using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataRequests
{
    public class Request_DangKyHoc
    {
        public int KhoaHocId { get; set; }
        public int HocVienId { get; set; }
        public int TinhTrangHocId { get; set; }
    }
}
