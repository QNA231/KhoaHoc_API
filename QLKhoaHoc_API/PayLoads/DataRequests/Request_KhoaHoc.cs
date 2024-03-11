using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataRequests
{
    public class Request_KhoaHoc
    {
        public string TenKhoaHoc { get; set; }
        public int ThoiGianHoc { get; set; }
        public string GioiThieu { get; set; }
        public string NoiDung { get; set; }
        public double HocPhi { get; set; }
        public int SoLuongMon { get; set; }
        public string HinhAnh { get; set; }
    }
}
