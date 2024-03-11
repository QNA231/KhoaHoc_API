namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_LoaiKhoaHoc
    {
        public string TenLoaiKhoaHoc { get; set; }
        public IQueryable<DataResponse_KhoaHoc> DataResponseKhoaHocs { get; set; }
    }
}
