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
    public class BaiVietServices : IBaiVietServices
    {
        private readonly AppDbContext dbContext;
        private ResponseObject<DataResponse_BaiViet> responseObject;
        private BaiVietConverter converter;

        public BaiVietServices(ResponseObject<DataResponse_BaiViet> responseObject, BaiVietConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public IQueryable<DataResponse_BaiViet> GetAll()
        {
            var result = dbContext.BaiViets.Select(x => converter.EntityToDTO(x));
            return result;
        }

        public PageResult<BaiViet> GetDsBaiViet(string? keyword, Pagination pagination)
        {
            var lstBaiViet = dbContext.BaiViets.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                lstBaiViet = lstBaiViet.Where(x => x.TenBaiViet.ToLower().Contains(keyword.ToLower()));
            }
            var result = PageResult<BaiViet>.ToPageResult(pagination, lstBaiViet).AsEnumerable();
            pagination.TotalCount = lstBaiViet.Count();
            return new PageResult<BaiViet>(pagination, result);
        }

        public ResponseObject<DataResponse_BaiViet> SuaBaiViet(Request_BaiViet request)
        {
            var bv = dbContext.BaiViets.SingleOrDefault(x => x.TenBaiViet == request.TenBaiViet);
            if(bv != null)
            {
                bv.TenBaiViet = request.TenBaiViet;
                bv.TenTacGia = request.TenTacGia;
                bv.NoiDung = request.NoiDung;
                bv.NoiDungNgan = request.NoiDungNgan;
                bv.HinhAnh = request.HinhAnh;
                bv.ChuDeId = request.chuDeId;
                dbContext.Update(bv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật bài viết thành công", converter.EntityToDTO(bv));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Bài viết không tồn tại", null);
        }

        public ResponseObject<DataResponse_BaiViet> ThemBaiViet(Request_BaiViet request)
        {
            if (dbContext.BaiViets.Any(x => x.TenBaiViet == request.TenBaiViet))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên bài viết đã tồn tại", null);
            }
            BaiViet bv = new BaiViet();
            bv.TenBaiViet = request.TenBaiViet;
            bv.TenTacGia = request.TenTacGia;
            bv.ThoiGianTao = DateTime.Now;
            bv.NoiDung = request.NoiDung;
            bv.NoiDungNgan = request.NoiDungNgan;
            bv.HinhAnh = request.HinhAnh;
            bv.TaiKhoanId = 1;
            bv.ChuDeId = request.chuDeId;
            dbContext.BaiViets.Add(bv);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm bài viết thành công", converter.EntityToDTO(bv));
        }

        public ResponseObject<DataResponse_BaiViet> XoaBaiViet(int tenID)
        {
            var bv = dbContext.BaiViets.SingleOrDefault(x => x.Id == tenID);
            if(bv != null)
            {
                dbContext.Remove(bv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa bài viết thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Bài viết không tồn tại", null);
        }
    }
}
