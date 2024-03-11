using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class TaiKhoanConverter
    {
        private readonly AppDbContext dbContext;

        public TaiKhoanConverter()
        {
            dbContext = new AppDbContext();
        }
        public DataResponse_TaiKhoan EntityToDTO(TaiKhoan taiKhoan)
        {
            return new DataResponse_TaiKhoan()
            {
                TenNguoiDung = taiKhoan.TenNguoiDung,
                TajKhoan = taiKhoan.TajKhoan,
                MatKhau = taiKhoan.MatKhau,
                TenQuyenHan = dbContext.QuyenHans.SingleOrDefault(x => x.Id == taiKhoan.QuyenHanId).TenQuyenHan,
            };
        }
    }
}
