using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface IHocVienServices
    {
        ResponseObject<DataResponse_HocVien> ThemHocVien(Request_HocVien request);
        ResponseObject<DataResponse_HocVien> XoaHocVien(int hvId);
        ResponseObject<DataResponse_HocVien> SuaHocVien(Request_HocVien request, int id);
        PageResult<HocVien> GetDsHocVien(string? keyword, Pagination pagination);
    }
}
