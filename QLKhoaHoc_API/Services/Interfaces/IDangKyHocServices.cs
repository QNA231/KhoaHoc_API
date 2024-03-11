using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface IDangKyHocServices
    {
        ResponseObject<DataResponse_DangKyHoc> ThemDangKy(Request_ThemDangKyHoc request, int tkId);
        ResponseObject<DataResponse_DangKyHoc> SuaDangKy(Request_DangKyHoc request, Request_HocVien request1, int id);
        ResponseObject<DataResponse_DangKyHoc> XoaDangKy(int id);
        PageResult<DangKyHoc> PhanTrangDangKy(Pagination pagination);
    }
}
