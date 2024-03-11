namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_LoaiBaiViet
    {
        public string TenLoaiBaiViet { get; set; }
        public IQueryable<DataResponse_ChuDe> DataResponseChuDes { get; set; }
    }
}
