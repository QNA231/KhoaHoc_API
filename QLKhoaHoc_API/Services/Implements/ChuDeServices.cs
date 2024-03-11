using Microsoft.EntityFrameworkCore;
using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.Converters;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;
using QLKhoaHoc_API.Services.Interfaces;

namespace QLKhoaHoc_API.Services.Implements
{
    public class ChuDeServices : IChuDeServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_ChuDe> responseObject;
        private readonly ChuDeConverter converter;

        public ChuDeServices(ResponseObject<DataResponse_ChuDe> responseObject, ChuDeConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public PageResult<ChuDe> PhanTrangChuDe(string? keyword, Pagination pagination)
        {
            var lstCd = dbContext.ChuDes.Include(x => x.baiViets).AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                lstCd = lstCd.Where(x => x.TenChuDe.ToLower().Contains(keyword.ToLower()));
            }
            var result = PageResult<ChuDe>.ToPageResult(pagination, lstCd).AsEnumerable();
            pagination.TotalCount = lstCd.Count();
            return new PageResult<ChuDe>(pagination, result);
        }

        public ResponseObject<DataResponse_ChuDe> SuaChuDe(Request_ChuDe request, int id)
        {
            if(dbContext.ChuDes.Any(x => x.Id == id))
            {
                var cd = dbContext.ChuDes.Find(id);
                cd.TenChuDe = request.TenChuDe;
                cd.NoiDung = request.NoiDung;
                dbContext.Update(cd);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật chủ đề thành công", converter.EntityToDTO(cd));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Chủ đề không tồn tại", null);
        }

        public ResponseObject<DataResponse_ChuDe> ThemChuDe(Request_ChuDe request, int lbvId)
        {
            if(dbContext.ChuDes.Any(x => x.TenChuDe == request.TenChuDe))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Chủ đề đã tồn tại", null);
            }
            ChuDe cd = new ChuDe();
            cd.TenChuDe = request.TenChuDe;
            cd.NoiDung = request.NoiDung;
            cd.LoaiBaiVietId = lbvId;
            dbContext.ChuDes.Add(cd);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm chủ đề thành công", converter.EntityToDTO(cd));
        }

        public ResponseObject<DataResponse_ChuDe> XoaChuDe(int id)
        {
            if (dbContext.ChuDes.Any(x => x.Id == id))
            {
                var cd = dbContext.ChuDes.Find(id);
                var bv = dbContext.BaiViets.SingleOrDefault(x => x.ChuDeId == id);
                if(bv != null)
                {
                    dbContext.Remove(bv);
                    dbContext.SaveChanges();
                    dbContext.Remove(cd);
                    dbContext.SaveChanges();
                    return responseObject.ResponseSuccess("Xóa chủ đề thành công", null);
                }
                else
                {
                    dbContext.Remove(cd);
                    dbContext.SaveChanges();
                    return responseObject.ResponseSuccess("Xóa chủ đề thành công", null);
                }
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Chủ đề không tồn tại", null);
        }
    }
}
