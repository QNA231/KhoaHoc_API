using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class BaiVietConverter
    {
        private readonly AppDbContext dbContext;

        public BaiVietConverter()
        {
            dbContext = new AppDbContext();
        }
        public DataResponse_BaiViet EntityToDTO(BaiViet baiViet)
        {
            return new DataResponse_BaiViet()
            {
                TenChuDe = dbContext.ChuDes.SingleOrDefault(x => x.Id == baiViet.ChuDeId).TenChuDe,
                TenBaiViet = baiViet.TenBaiViet,
                ThoiGianTao = baiViet.ThoiGianTao,
                TenTacGia = dbContext.TaiKhoans.SingleOrDefault(x => x.Id == baiViet.TaiKhoanId).TajKhoan,
                NoiDungNgan = baiViet.NoiDungNgan,
                HinhAnh = baiViet.HinhAnh,
            };
        }
    }
}
