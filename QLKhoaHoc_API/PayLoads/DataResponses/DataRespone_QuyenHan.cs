using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataRespone_QuyenHan
    {
        public string TenQuyenHan { get; set; }
        public IQueryable<DataResponse_TaiKhoan> DataResponseTaiKhoans { get; set; }
    }
}
