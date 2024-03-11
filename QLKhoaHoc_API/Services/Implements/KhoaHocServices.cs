using Microsoft.AspNetCore.Mvc;
using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.Converters;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;
using QLKhoaHoc_API.Services.Interfaces;

namespace QLKhoaHoc_API.Services.Implements
{
    public class KhoaHocServices : IKhoaHocServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_KhoaHoc> responseObject;
        private readonly KhoaHocConverter converter;

        public KhoaHocServices(ResponseObject<DataResponse_KhoaHoc> responseObject, KhoaHocConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public ResponseObject<DataResponse_KhoaHoc> HienThiDanhSachKhoaHoc()
        {
            throw new NotImplementedException();
        }

        public PageResult<KhoaHoc> PhanTrangKhoaHoc([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            var kh = dbContext.KhoaHocs.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                kh = kh.Where(x => x.TenKhoaHoc.Contains(keyword.ToLower()));
            }
            var result = PageResult<KhoaHoc>.ToPageResult(pagination, kh).AsEnumerable();
            pagination.TotalCount = kh.Count();
            return new PageResult<KhoaHoc>(pagination, result);
        }

        public ResponseObject<DataResponse_KhoaHoc> SuaKhoaHoc(Request_KhoaHoc request, int khId)
        {
            if (dbContext.KhoaHocs.Any(x => x.Id == khId))
            {
                var kh = dbContext.KhoaHocs.Find(khId);
                kh.TenKhoaHoc = request.TenKhoaHoc;
                kh.ThoiGianHoc = request.ThoiGianHoc;
                kh.GioiThieu = request.GioiThieu;
                kh.NoiDung = request.NoiDung;
                kh.HocPhi = request.HocPhi;
                kh.SoLuongMon = request.SoLuongMon;
                kh.HinhAnh = request.HinhAnh;
                dbContext.KhoaHocs.Update(kh);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật thông tin khóa học thành công", converter.EntityToDTO(kh));
            }
            return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khóa học không tồn tại", null);
        }

        public ResponseObject<DataResponse_KhoaHoc> ThemKhoaHoc(Request_KhoaHoc request, int lkhId)
        {
            if(dbContext.LoaiKhoaHocs.Any(x => x.Id == lkhId))
            {
                if(!dbContext.KhoaHocs.Any(x => x.TenKhoaHoc == request.TenKhoaHoc))
                {
                    KhoaHoc kh = new KhoaHoc();
                    kh.LoaiKhoaHocId = lkhId;
                    kh.TenKhoaHoc = request.TenKhoaHoc;
                    kh.HocPhi = request.HocPhi;
                    kh.SoHocVien = 0;
                    kh.GioiThieu = request.GioiThieu;
                    kh.NoiDung = request.NoiDung;
                    kh.ThoiGianHoc = request.ThoiGianHoc;
                    kh.SoLuongMon = request.SoLuongMon;
                    kh.HinhAnh = request.HinhAnh;
                    dbContext.Add(kh);
                    dbContext.SaveChanges();
                    return responseObject.ResponseSuccess("Thêm khóa học thành công", converter.EntityToDTO(kh));
                }
                else
                {
                    return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Khóa học đã tồn tại", null);
                }
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Thêm khóa học thất bại", null);
        }

        public ResponseObject<DataResponse_KhoaHoc> XoaKhoaHoc(int khId)
        {
            if(dbContext.KhoaHocs.Any(x => x.Id == khId))
            {
                var kh = dbContext.KhoaHocs.Find(khId);
                dbContext.Remove(kh);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa khóa học thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khóa học không tồn tại", null);
        }
    }
}
