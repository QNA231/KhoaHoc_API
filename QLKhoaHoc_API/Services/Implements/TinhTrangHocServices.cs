using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.Converters;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;
using QLKhoaHoc_API.Services.Interfaces;

namespace QLKhoaHoc_API.Services.Implements
{
    public class TinhTrangHocServices : ITinhTrangHocServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_TinhTrangHoc> responseObject;
        private readonly TinhTrangHocConverter converter;

        public TinhTrangHocServices(ResponseObject<DataResponse_TinhTrangHoc> responseObject, TinhTrangHocConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public IQueryable<TinhTrangHoc> HienThiTinhTrangHoc()
        {
            return dbContext.TinhTrangHocs.AsQueryable();
        }

        public ResponseObject<DataResponse_TinhTrangHoc> SuaTinhTrangHoc(Request_TinhTrangHoc request, int id)
        {
            var th = dbContext.TinhTrangHocs.Find(id);
            if(th != null)
            {
                th.TenTinhTrang = request.TenTinhTrang;
                dbContext.Update(th);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật tình trạng học thành công", converter.EntityToDTO(th));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tình trạng học không tồn tại", null);
        }

        public ResponseObject<DataResponse_TinhTrangHoc> ThemTinhTrangHoc(Request_TinhTrangHoc request)
        {
            if(dbContext.TinhTrangHocs.Any(x => x.TenTinhTrang == request.TenTinhTrang))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tình trạng học đã tồn tại", null);
            }
            TinhTrangHoc th = new TinhTrangHoc();
            th.TenTinhTrang = request.TenTinhTrang;
            dbContext.Add(th);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm tình trạng học thành công", converter.EntityToDTO(th));
        }

        public ResponseObject<DataResponse_TinhTrangHoc> XoaTinhTrangHoc(int id)
        {
            if(dbContext.TinhTrangHocs.Any(x => x.Id == id))
            {
                var th = dbContext.TinhTrangHocs.Find(id);
                dbContext.Remove(th);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa tình trạng học thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tình trạng học không tồn tại", null);
        }
    }
}
