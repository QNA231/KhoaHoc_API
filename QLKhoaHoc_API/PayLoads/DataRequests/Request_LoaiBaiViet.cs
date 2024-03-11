namespace QLKhoaHoc_API.PayLoads.DataRequests
{
    public class Request_LoaiBaiViet
    {
        public string TenLoaiBaiViet { get; set; }
        public List<Request_ChuDe> ThemChuDes { get; set; }
    }
}
