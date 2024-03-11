using Microsoft.AspNetCore.Mvc.RazorPages;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface IKhoaHocServices
    {
        ResponseObject<DataResponse_KhoaHoc> ThemKhoaHoc(Request_KhoaHoc request, int lkhId);
        ResponseObject<DataResponse_KhoaHoc> SuaKhoaHoc(Request_KhoaHoc request, int khId);
        ResponseObject<DataResponse_KhoaHoc> XoaKhoaHoc(int khId);
        ResponseObject<DataResponse_KhoaHoc> HienThiDanhSachKhoaHoc();
        PageResult<KhoaHoc> PhanTrangKhoaHoc(string? keyword, Pagination pagination);
    }
}
