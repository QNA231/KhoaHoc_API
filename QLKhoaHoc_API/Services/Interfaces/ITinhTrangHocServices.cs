using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.Services.Interfaces
{
    public interface ITinhTrangHocServices
    {
        ResponseObject<DataResponse_TinhTrangHoc> ThemTinhTrangHoc(Request_TinhTrangHoc request);
        ResponseObject<DataResponse_TinhTrangHoc> SuaTinhTrangHoc(Request_TinhTrangHoc request, int id);
        ResponseObject<DataResponse_TinhTrangHoc> XoaTinhTrangHoc(int id);
        IQueryable<TinhTrangHoc> HienThiTinhTrangHoc();
    }
}
