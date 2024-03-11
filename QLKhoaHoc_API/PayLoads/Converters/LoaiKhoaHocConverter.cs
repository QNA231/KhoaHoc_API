using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class LoaiKhoaHocConverter
    {
        private readonly AppDbContext dbContext;
        private readonly KhoaHocConverter converter;

        public LoaiKhoaHocConverter()
        {
            dbContext = new AppDbContext();
            converter = new KhoaHocConverter();
        }
        public DataResponse_LoaiKhoaHoc EntityToDTO(LoaiKhoaHoc loaiKhoaHoc)
        {
            return new DataResponse_LoaiKhoaHoc()
            {
                TenLoaiKhoaHoc = loaiKhoaHoc.TenLoaiKhoaHoc,
                DataResponseKhoaHocs = dbContext.KhoaHocs.Where(x => x.Id == loaiKhoaHoc.Id).Select(x => converter.EntityToDTO(x))
            };
        }
    }
}
