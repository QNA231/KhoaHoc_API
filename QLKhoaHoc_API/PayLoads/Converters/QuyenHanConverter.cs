using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.PayLoads.DataResponses;

namespace QLKhoaHoc_API.PayLoads.Converters
{
    public class QuyenHanConverter
    {
        private readonly AppDbContext dbContext;
        private readonly TaiKhoanConverter converter;

        public QuyenHanConverter(TaiKhoanConverter converter)
        {
            dbContext = new AppDbContext() ;
            this.converter = converter;
        }
        public DataRespone_QuyenHan EntityToDTO(QuyenHan quyenHan)
        {
            return new DataRespone_QuyenHan()
            {
                TenQuyenHan = quyenHan.TenQuyenHan,
                DataResponseTaiKhoans = dbContext.TaiKhoans.Where(x => x.QuyenHanId == quyenHan.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
