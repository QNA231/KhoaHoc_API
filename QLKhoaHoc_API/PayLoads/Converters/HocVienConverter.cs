using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class HocVienConverter
    {
        private readonly AppDbContext dbContext;
        private readonly DangKyHocConverter converter;

        public HocVienConverter(DangKyHocConverter converter)
        {
            dbContext = new AppDbContext();
            this.converter = converter;
        }
        public DataResponse_HocVien EntityTODTO(HocVien hocVien)
        {
            return new DataResponse_HocVien()
            {
                HinhAnh = hocVien.HinhAnh,
                HoTen = hocVien.HoTen,
                NgaySinh = hocVien.NgaySinh,
                SDT = hocVien.SDT,
                Email = hocVien.Email,
                TinhThanh = hocVien.TinhThanh,
                dangKyHocs = dbContext.DangKyHocs.Where(x => x.HocVIenId == hocVien.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
