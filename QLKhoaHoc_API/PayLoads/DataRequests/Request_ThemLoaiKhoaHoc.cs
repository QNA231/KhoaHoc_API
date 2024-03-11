namespace QLKhoaHoc_API.PayLoads.DataRequests
{
    public class Request_ThemLoaiKhoaHoc
    {
        public string TenLoaiKhoaHoc { get; set; }
        public List<Request_KhoaHoc> ThemKhoaHocs { get; set; }
    }
}
