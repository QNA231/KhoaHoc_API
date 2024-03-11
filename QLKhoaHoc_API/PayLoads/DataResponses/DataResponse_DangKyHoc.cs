using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_DangKyHoc
    {
        public string TenKhoaHoc { get; set; }
        public string TenHocVien { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TenTinhTrangHoc { get; set; }
        public string TenTaiKhoan { get; set; }
    }
}
