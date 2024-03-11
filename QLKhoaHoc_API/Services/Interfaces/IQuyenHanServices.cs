using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface IQuyenHanServices
    {
        ResponseObject<DataRespone_QuyenHan> ThemQuyenHan(Request_QuyenHan request);
        ResponseObject<DataRespone_QuyenHan> SuaQuyenHan(Request_QuyenHan request, int id);
        ResponseObject<DataRespone_QuyenHan> XoaQuyenHan(int id);
    }
}
