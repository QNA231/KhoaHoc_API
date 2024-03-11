using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class DangKyHocConverter
    {
        private readonly AppDbContext dbContext;

        public DangKyHocConverter()
        {
            dbContext = new AppDbContext();
        }
        public DataResponse_DangKyHoc EntityToDTO(DangKyHoc dangKyHoc)
        {
            return new DataResponse_DangKyHoc()
            {
                TenKhoaHoc = dbContext.KhoaHocs.SingleOrDefault(x => x.Id == dangKyHoc.KhoaHocId)?.TenKhoaHoc ?? "",
                TenHocVien = dbContext.HocViens.SingleOrDefault(x => x.Id == dangKyHoc.HocVIenId)?.HoTen ?? "",
                NgayDangKy = dangKyHoc.NgayDangKy,
                NgayBatDau = dangKyHoc.NgayBatDau,
                NgayKetThuc = dangKyHoc.NgayKetThuc,
                TenTinhTrangHoc = dbContext.TinhTrangHocs.SingleOrDefault(x => x.Id == dangKyHoc.TinhTrangHocId)?.TenTinhTrang ?? "",
                TenTaiKhoan = dbContext.TaiKhoans.SingleOrDefault(x => x.Id == dangKyHoc.TaiKhoanId)?.TajKhoan ?? "",
            };
        }
    }
}
