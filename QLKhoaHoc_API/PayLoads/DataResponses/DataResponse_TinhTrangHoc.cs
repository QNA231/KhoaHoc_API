using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_TinhTrangHoc
    {
        public string TenTinhTrang { get; set; }
        public IQueryable<DataResponse_DangKyHoc> DataResponseDangKyHocs { get; set; }
    }
}
