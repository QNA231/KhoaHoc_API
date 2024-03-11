using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.Converters;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;
using QLKhoaHoc_API.Services.Interfaces;

namespace QLKhoaHoc_API.Services.Implements
{
    public class LoaiKhoaHocServices : ILoaiKhoaHocServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_LoaiKhoaHoc> responseObject;
        private readonly LoaiKhoaHocConverter converter;

        public LoaiKhoaHocServices(ResponseObject<DataResponse_LoaiKhoaHoc> responseObject, LoaiKhoaHocConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public ResponseObject<DataResponse_LoaiKhoaHoc> SuaLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request1, int id)
        {
            if(dbContext.LoaiKhoaHocs.Any(x => x.Id == id))
            {
                var lkh = dbContext.LoaiKhoaHocs.Find(id);
                lkh.TenLoaiKhoaHoc = request1.TenLoaiKhoaHoc;
                dbContext.Update(lkh);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật loại khóa học thành công", converter.EntityToDTO(lkh));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Khóa học không tồn tại", null);
        }

        public ResponseObject<DataResponse_LoaiKhoaHoc> ThemLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request)
        {
            var lkh = dbContext.LoaiKhoaHocs.SingleOrDefault(x => x.TenLoaiKhoaHoc == request.TenLoaiKhoaHoc);
            if (lkh != null) 
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Trùng tên loại khóa học", null);
            }
            LoaiKhoaHoc loaiKhoaHoc = new LoaiKhoaHoc();
            loaiKhoaHoc.TenLoaiKhoaHoc = request.TenLoaiKhoaHoc;
            dbContext.LoaiKhoaHocs.Add(loaiKhoaHoc);
            dbContext.SaveChanges();
            loaiKhoaHoc.khoaHocs = ThemListKhoaHoc(loaiKhoaHoc.Id, request.ThemKhoaHocs);
            dbContext.LoaiKhoaHocs.Update(loaiKhoaHoc);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm loại khóa học thành công", converter.EntityToDTO(loaiKhoaHoc));
        }

        private List<KhoaHoc> ThemListKhoaHoc(int loaiKHId, List<Request_KhoaHoc> requests)
        {
            var loaiKH = dbContext.LoaiKhoaHocs.SingleOrDefault(x => x.Id == loaiKHId);
            if(loaiKH == null)
            {
                return null;
            }
            List<KhoaHoc> lst = new List<KhoaHoc>();
            foreach(var request in requests)
            {
                KhoaHoc kh = new KhoaHoc();
                kh.LoaiKhoaHocId = loaiKHId;
                kh.TenKhoaHoc = request.TenKhoaHoc;
                kh.ThoiGianHoc = request.ThoiGianHoc;
                kh.GioiThieu = request.GioiThieu;
                kh.NoiDung = request.NoiDung;
                kh.HocPhi = request.HocPhi;
                kh.SoLuongMon = request.SoLuongMon;
                kh.HinhAnh = request.HinhAnh;
                lst.Add(kh);
            }
            dbContext.KhoaHocs.AddRange(lst);
            dbContext.SaveChanges();
            return lst;
        }

        public ResponseObject<DataResponse_LoaiKhoaHoc> XoaLoaiKhoaHoc(Request_XoaLoaiKhoaHoc request)
        {
            if(dbContext.LoaiKhoaHocs.Any(x => x.Id == request.Id))
            {
                if(dbContext.KhoaHocs.Any(x => x.LoaiKhoaHocId == request.Id))
                {
                    var kh = dbContext.KhoaHocs.Find(request.Id);
                    dbContext.Remove(kh);
                    dbContext.SaveChanges();

                    var lkh = dbContext.LoaiKhoaHocs.Find(request.Id);
                    dbContext.Remove(lkh);
                    dbContext.SaveChanges();
                    return responseObject.ResponseSuccess("Xóa khóa học thành công", null);
                }
                else
                {
                    var lkh = dbContext.LoaiKhoaHocs.Find(request.Id);
                    dbContext.Remove(lkh);
                    dbContext.SaveChanges();
                    return responseObject.ResponseSuccess("Xóa khóa học thành công", null);
                }
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Khóa học không tồn tại", null);
        }
    }
}
