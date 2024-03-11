using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class ChuDeConverter
    {
        private readonly AppDbContext dbContext;
        private readonly BaiVietConverter converter;

        public ChuDeConverter(BaiVietConverter converter)
        {
            dbContext = new AppDbContext();
            this.converter = converter;
        }
        public DataResponse_ChuDe EntityToDTO(ChuDe chuDe)
        {
            return new DataResponse_ChuDe()
            {
                TenChuDe = chuDe.TenChuDe,
                NoiDung = chuDe.NoiDung,
                TenLoaiBaiViet = dbContext.LoaiBaiViets.SingleOrDefault(x => x.Id == chuDe.LoaiBaiVietId).TenLoaiBaiViet,
                DataResponseBaiViets = dbContext.BaiViets.Where(x => x.ChuDeId == chuDe.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
