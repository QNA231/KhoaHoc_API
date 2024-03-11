using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class KhoaHocConverter
    {
        private readonly AppDbContext dbContext;

        public KhoaHocConverter()
        {
            dbContext = new AppDbContext();
        }
        public DataResponse_KhoaHoc EntityToDTO(KhoaHoc KhoaHoc)
        {
            return new DataResponse_KhoaHoc()
            {
                TenKhoaHoc = KhoaHoc.TenKhoaHoc,
                ThoiGianHoc = KhoaHoc.ThoiGianHoc,
                SoHocVien = KhoaHoc.SoHocVien,
                SoLuongMon = KhoaHoc.SoLuongMon
            };
        }
    }
}
