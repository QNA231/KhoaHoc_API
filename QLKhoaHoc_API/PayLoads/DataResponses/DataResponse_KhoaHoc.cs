using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_KhoaHoc
    {
        public string TenKhoaHoc { get; set; }
        public int? ThoiGianHoc { get; set; }
        public int? SoHocVien { get; set; }
        public int? SoLuongMon { get; set; }
    }
}
