using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_HocVien
    {
        public string HinhAnh { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string TinhThanh { get; set; }
        public IQueryable<DataResponse_DangKyHoc> dangKyHocs { get; set; }
    }
}
