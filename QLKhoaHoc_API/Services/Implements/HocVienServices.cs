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
    public class HocVienServices : IHocVienServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_HocVien> responseObject;
        private readonly HocVienConverter converter;

        public HocVienServices(ResponseObject<DataResponse_HocVien> responseObject, HocVienConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public PageResult<HocVien> GetDsHocVien(string? keyword, Pagination pagination)
        {
            var lstHv = dbContext.HocViens.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                lstHv = lstHv.Where(x => x.HoTen.ToLower().Contains(keyword.ToLower()) || x.Email.ToLower().Contains(keyword.ToLower()));
            }
            var result = PageResult<HocVien>.ToPageResult(pagination, lstHv).AsEnumerable();
            pagination.TotalCount = lstHv.Count();
            return new PageResult<HocVien>(pagination, result);
        }

        public ResponseObject<DataResponse_HocVien> SuaHocVien(Request_HocVien request, int id)
        {
            if(dbContext.HocViens.Any(x => x.Id == id))
            {
                var hv = dbContext.HocViens.Find(id);
                var sdt = dbContext.HocViens.FirstOrDefault(x => x.SDT == request.SDT);
                var mail = dbContext.HocViens.FirstOrDefault(x => x.Email == request.Email);
                hv.HinhAnh = request.HinhAnh;
                hv.HoTen = request.HoTen;
                hv.NgaySinh = request.NgaySinh;
                hv.SDT = request.SDT;
                hv.Email = request.Email;
                hv.TinhThanh = request.TinhThanh;
                hv.QuanHuyen = request.QuanHuyen;
                hv.PhuongXa = request.PhuongXa;
                hv.SoNha = request.SoNha;
                if (sdt != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Số điện thoại đã tồn tại", null);
                }
                if (mail != null)
                {
                    return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email đã tồn tại", null);
                }
                dbContext.Update(hv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật thông tin học viên thành công", converter.EntityTODTO(hv));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Học viên không tồn tại", null);
        }

        public ResponseObject<DataResponse_HocVien> ThemHocVien(Request_HocVien request)
        {
            HocVien hv = new HocVien();
            var sdt = dbContext.HocViens.FirstOrDefault(x => x.SDT == request.SDT);
            var mail = dbContext.HocViens.FirstOrDefault(x => x.Email == request.Email);
            hv.HinhAnh = request.HinhAnh;
            hv.HoTen = DinhDangHoTen(request.HoTen);
            hv.NgaySinh = request.NgaySinh;
            hv.SDT = request.SDT;
            hv.Email = request.Email;
            hv.TinhThanh = request.TinhThanh;
            hv.QuanHuyen = request.QuanHuyen;
            hv.PhuongXa = request.PhuongXa;
            hv.SoNha = request.SoNha;
            if(sdt != null)
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Số điện thoại đã tồn tại", null);
            }
            if (mail != null)
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email đã tồn tại", null);
            }
            dbContext.HocViens.Add(hv);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm học viên thành công", converter.EntityTODTO(hv));
        }

        private string DinhDangHoTen(string fullname)
        {
            string[] namepart = fullname.Split(' ');
            if(namepart.Length == 1)
            {
                return fullname;
            }
            for(int i = 0; i < namepart.Length; i++)
            {
                namepart[i] = char.ToUpper(namepart[i][0]) + namepart[i].Substring(1).ToLower();
            }
            string result = string.Join(" ", namepart);
            return result;
        }

        public ResponseObject<DataResponse_HocVien> XoaHocVien(int hvId)
        {
            if(dbContext.HocViens.Any(x => x.Id == hvId))
            {
                var dk = dbContext.DangKyHocs.SingleOrDefault(x => x.HocVIenId == hvId);
                var hv = dbContext.HocViens.Find(hvId);
                if(dk != null)
                {
                    var soHocVien = dbContext.KhoaHocs.SingleOrDefault(x => x.Id == dk.KhoaHocId);
                    if (soHocVien != null)
                    {
                        soHocVien.SoHocVien--;
                        dbContext.KhoaHocs.Update(soHocVien);
                        dbContext.SaveChanges();
                    }
                    dbContext.Remove(dk);
                    dbContext.SaveChanges();
                }

                dbContext.Remove(hv);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa học viên thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Học viên không tồn tại", null);
        }
    }
}
