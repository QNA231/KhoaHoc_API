using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface ITaiKhoanServices
    {
        ResponseObject<DataResponse_TaiKhoan> ThemTaiKhoan(Request_ThemTaiKhoan request);
        ResponseObject<DataResponse_TaiKhoan> SuaTaiKhoan(Request_ThemTaiKhoan request, int id);
        ResponseObject<DataResponse_TaiKhoan> XoaTaiKhoan(int id);
        PageResult<TaiKhoan> GetDsTaiKhoan(string? keyword, Pagination pagination);
        DataResponse_Token GenerateAccessToken(TaiKhoan taiKhoan);
        DataResponse_Token RenewAccessToken(Request_RenewAccessToken request);
        ResponseObject<DataResponse_Token> Login(Request_Login request);
        IQueryable<DataResponse_TaiKhoan> GetAll();
    }
}
