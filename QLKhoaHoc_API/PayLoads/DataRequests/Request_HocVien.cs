using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataRequests
{
    public class Request_HocVien
    {
        public string? HinhAnh { get; set; }
        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public string? TinhThanh { get; set; }
        public string? QuanHuyen { get; set; }
        public string? PhuongXa { get; set; }
        public int? SoNha { get; set; }
        //public List<Request_DangKyHoc> dangKyHocs { get; set; }
    }
}
