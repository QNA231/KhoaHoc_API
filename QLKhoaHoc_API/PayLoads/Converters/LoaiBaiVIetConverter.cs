using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class LoaiBaiVIetConverter
    {
        private readonly AppDbContext dbContext;
        private readonly ChuDeConverter converter;

        public LoaiBaiVIetConverter(ChuDeConverter converter)
        {
            dbContext = new AppDbContext();
            this.converter = converter;
        }

        public DataResponse_LoaiBaiViet EntityToDTO(LoaiBaiViet loaiBaiViet)
        {
            return new DataResponse_LoaiBaiViet()
            {
                TenLoaiBaiViet = loaiBaiViet.TenLoaiBaiViet,
                DataResponseChuDes = dbContext.ChuDes.Where(x => x.LoaiBaiVietId == loaiBaiViet.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
