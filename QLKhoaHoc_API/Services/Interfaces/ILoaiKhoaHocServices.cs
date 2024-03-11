using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface ILoaiKhoaHocServices
    {
        ResponseObject<DataResponse_LoaiKhoaHoc> ThemLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request);
        ResponseObject<DataResponse_LoaiKhoaHoc> SuaLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request1, int id);
        ResponseObject<DataResponse_LoaiKhoaHoc> XoaLoaiKhoaHoc(Request_XoaLoaiKhoaHoc request);
    }
}
