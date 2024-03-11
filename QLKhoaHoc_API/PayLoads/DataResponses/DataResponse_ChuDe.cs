using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_ChuDe
    {
        public string TenChuDe { get; set; }
        public string NoiDung { get; set; }
        public string TenLoaiBaiViet { get; set; }
        public IQueryable<DataResponse_BaiViet> DataResponseBaiViets { get; set; }
    }
}
