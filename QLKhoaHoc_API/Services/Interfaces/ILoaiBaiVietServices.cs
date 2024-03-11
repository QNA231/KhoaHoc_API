using Microsoft.AspNetCore.Mvc.RazorPages;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface ILoaiBaiVietServices
    {
        ResponseObject<DataResponse_LoaiBaiViet> ThemLoaiBaiViet(Request_LoaiBaiViet request);
        ResponseObject<DataResponse_LoaiBaiViet> SuaLoaiBaiViet(Request_LoaiBaiViet request, int id);
        ResponseObject<DataResponse_LoaiBaiViet> XoaLoaiBaiViet(int id);
        PageResult<LoaiBaiViet> GetDsLoaiBaiViet(string? keyword, Pagination pagination);
    }
}
