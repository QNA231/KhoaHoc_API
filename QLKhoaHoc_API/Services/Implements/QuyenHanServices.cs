using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.Converters;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;
using QLKhoaHoc_API.Services.Interfaces;

namespace QLKhoaHoc_API.Services.Implements
{
    public class QuyenHanServices : IQuyenHanServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataRespone_QuyenHan> responseObject;
        private readonly QuyenHanConverter converter;

        public QuyenHanServices(ResponseObject<DataRespone_QuyenHan> responseObject, QuyenHanConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public ResponseObject<DataRespone_QuyenHan> SuaQuyenHan(Request_QuyenHan request, int id)
        {
            if(dbContext.QuyenHans.Any(x => x.Id == id))
            {
                var qh = dbContext.QuyenHans.Find(id);
                qh.TenQuyenHan = request.TenQuyenHan;
                dbContext.Update(qh);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật quyền hạn thành công", converter.EntityToDTO(qh));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Quyền hạn không tồn tại", null);
        }

        public ResponseObject<DataRespone_QuyenHan> ThemQuyenHan(Request_QuyenHan request)
        {
            if(dbContext.QuyenHans.Any(x => x.TenQuyenHan == request.TenQuyenHan))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên quyền hạn đã tồn tại", null);
            }
            QuyenHan qh = new QuyenHan();
            qh.TenQuyenHan = request.TenQuyenHan;
            dbContext.Add(qh);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm quyền hạn thành công", converter.EntityToDTO(qh));
        }

        public ResponseObject<DataRespone_QuyenHan> XoaQuyenHan(int id)
        {
            if (dbContext.QuyenHans.Any(x => x.Id == id))
            {
                var qh = dbContext.QuyenHans.Find(id);
                dbContext.Remove(qh);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa quyền hạn thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Quyền hạn không tồn tại", null);
        }
    }
}
