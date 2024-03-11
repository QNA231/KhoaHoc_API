using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class TinhTrangHocConverter
    {
        private readonly AppDbContext dbContext;

        public TinhTrangHocConverter()
        {
            dbContext = new AppDbContext();
        }
        public DataResponse_TinhTrangHoc EntityToDTO(TinhTrangHoc tinhTrangHoc)
        {
            return new DataResponse_TinhTrangHoc()
            {
                TenTinhTrang = tinhTrangHoc.TenTinhTrang,
            };
        }
    }
}
