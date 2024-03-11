using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface IBaiVietServices
    {
        ResponseObject<DataResponse_BaiViet> ThemBaiViet(Request_BaiViet request, int cdId);
        ResponseObject<DataResponse_BaiViet> SuaBaiViet(Request_BaiViet request, int id);
        ResponseObject<DataResponse_BaiViet> XoaBaiViet(int id);
        PageResult<BaiViet> GetDsBaiViet(string? keyword, Pagination pagination);
    }
}
