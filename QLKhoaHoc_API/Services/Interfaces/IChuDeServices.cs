using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface IChuDeServices
    {
        ResponseObject<DataResponse_ChuDe> ThemChuDe(Request_ChuDe request, int lbvId);
        ResponseObject<DataResponse_ChuDe> SuaChuDe(Request_ChuDe request, int id);
        ResponseObject<DataResponse_ChuDe> XoaChuDe(int id);
        PageResult<ChuDe> PhanTrangChuDe(string? keyword, Pagination pagination);
    }
}
