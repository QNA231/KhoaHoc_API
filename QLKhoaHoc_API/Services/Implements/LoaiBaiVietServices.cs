using Azure.Core;
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
    public class LoaiBaiVietServices : ILoaiBaiVietServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_LoaiBaiViet> responseObject;
        private readonly LoaiBaiVIetConverter converter;

        public LoaiBaiVietServices(ResponseObject<DataResponse_LoaiBaiViet> responseObject, LoaiBaiVIetConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public PageResult<LoaiBaiViet> GetDsLoaiBaiViet(string? keyword, Pagination pagination)
        {
            var lbv = dbContext.LoaiBaiViets.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                lbv = lbv.Where(x => x.TenLoaiBaiViet.Contains(keyword.ToLower()));
            }
            var result = PageResult<LoaiBaiViet>.ToPageResult(pagination, lbv).AsEnumerable();
            pagination.TotalCount = lbv.Count();
            return new PageResult<LoaiBaiViet>(pagination, result);
        }

        public ResponseObject<DataResponse_LoaiBaiViet> SuaLoaiBaiViet(Request_LoaiBaiViet request, int id)
        {
            if (dbContext.LoaiBaiViets.Any(x => x.Id == id))
            {
                var lbv = dbContext.LoaiBaiViets.Find(id);
                lbv.TenLoaiBaiViet = request.TenLoaiBaiViet;
                dbContext.Update(lbv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật loại bài viết thành công", converter.EntityToDTO(lbv));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Loại bài viết không tồn tại", null);
        }

        public ResponseObject<DataResponse_LoaiBaiViet> ThemLoaiBaiViet(Request_LoaiBaiViet request)
        {
            if(dbContext.LoaiBaiViets.Any(x => x.TenLoaiBaiViet == request.TenLoaiBaiViet))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Loại bài viết đã tồn tại", null);
            }
            LoaiBaiViet lbv = new LoaiBaiViet();
            lbv.TenLoaiBaiViet = request.TenLoaiBaiViet;
            dbContext.Add(lbv);
            dbContext.SaveChanges();
            lbv.chuDes = ThemListChuDe(lbv.Id, request.ThemChuDes);
            dbContext.Update(lbv);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm loại bài viết thành công", converter.EntityToDTO(lbv));
        }
        private List<ChuDe> ThemListChuDe(int lbvId, List<Request_ChuDe> requests)
        {
            if(!dbContext.LoaiBaiViets.Any(x => x.Id == lbvId))
            {
                return null;
            }
            List<ChuDe> list = new List<ChuDe>();
            foreach(var item in requests)
            {
                var chuDe = new ChuDe();
                chuDe.LoaiBaiVietId = lbvId;
                chuDe.TenChuDe = item.TenChuDe;
                chuDe.NoiDung = item.NoiDung;
                list.Add(chuDe);
            }
            dbContext.AddRange(list);
            dbContext.SaveChanges();
            return list;
        }

        public ResponseObject<DataResponse_LoaiBaiViet> XoaLoaiBaiViet(int id)
        {
            var lbv = dbContext.LoaiBaiViets.Find(id);
            var cd = dbContext.ChuDes.SingleOrDefault(x => x.LoaiBaiVietId == id);
            var bv = dbContext.BaiViets.SingleOrDefault(x => x.ChuDeId == cd.Id);
            if(bv == null && cd == null)
            {
                dbContext.Remove(lbv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa loại bài viết thành công", null);
            }else if(bv == null)
            {
                dbContext.Remove(cd);
                dbContext.SaveChanges();
                dbContext.Remove(lbv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa loại bài viết thành công", null);
            }
            else
            {
                dbContext.Remove(bv);
                dbContext.SaveChanges();
                dbContext.Remove(cd);
                dbContext.SaveChanges();
                dbContext.Remove(lbv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa loại bài viết thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Loại bài viết không tồn tại", null);
        }
    }
}
