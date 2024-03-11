using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_BaiViet
    {
        public string TenChuDe { get; set; }
        public string TenBaiViet { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string TenTacGia { get; set; }
        public string NoiDungNgan { get; set; }
        public string HinhAnh { get; set; }
    }
}
