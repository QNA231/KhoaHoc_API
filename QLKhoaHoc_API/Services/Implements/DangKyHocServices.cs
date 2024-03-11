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
    public class DangKyHocServices : IDangKyHocServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_DangKyHoc> responseObject;
        private DangKyHocConverter converter;
        private readonly ResponseObject<DataResponse_HocVien> responseObjecthv;
        private readonly HocVienConverter converterhv;

        public DangKyHocServices(ResponseObject<DataResponse_DangKyHoc> responseObject, DangKyHocConverter converter, ResponseObject<DataResponse_HocVien> responseObjecthv, HocVienConverter converterhv)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
            this.responseObjecthv = responseObjecthv;
            this.converterhv = converterhv;
        }

        public PageResult<DangKyHoc> PhanTrangDangKy(Pagination pagination)
        {
            var lstDk = dbContext.DangKyHocs.AsQueryable();
            var result = PageResult<DangKyHoc>.ToPageResult(pagination, lstDk).AsEnumerable();
            pagination.TotalCount = lstDk.Count();
            return new PageResult<DangKyHoc>(pagination, result);
        }

        public ResponseObject<DataResponse_DangKyHoc> SuaDangKy(Request_DangKyHoc request, Request_HocVien request1, int id)
        {
            var dk = dbContext.DangKyHocs.Find(id);
            var kh = dbContext.KhoaHocs.SingleOrDefault(x => x.Id == request.KhoaHocId);
            var tgh = kh.ThoiGianHoc;
            dk.TinhTrangHocId = request.TinhTrangHocId;
            if (request.TinhTrangHocId == 2)
            {
                dk.NgayBatDau = DateTime.Now;
                HocVien hv = new HocVien();
                var sdt = dbContext.HocViens.FirstOrDefault(x => x.SDT == request1.SDT);
                var mail = dbContext.HocViens.FirstOrDefault(x => x.Email == request1.Email);
                hv.HinhAnh = request1.HinhAnh;
                hv.HoTen =  "";
                hv.NgaySinh = request1.NgaySinh;
                hv.SDT = request1.SDT;
                hv.Email = request1.Email;
                hv.TinhThanh = request1.TinhThanh;
                hv.QuanHuyen = request1.QuanHuyen;
                hv.PhuongXa = request1.PhuongXa;
                hv.SoNha = request1.SoNha;
                dbContext.HocViens.Add(hv);
                dbContext.SaveChanges();
                dk.HocVIenId = hv.Id;
                dbContext.SaveChanges();
            }
            if (DateTime.Now > dk.NgayKetThuc)
            {
                dk.TinhTrangHocId = 3;
            }
            if(dk.TinhTrangHocId == 4 || dk.TinhTrangHocId == 3)
            {
                var shv = kh.SoHocVien;
                shv--;
                dbContext.KhoaHocs.Update(kh);
                dbContext.SaveChanges();
            }
            if (dk.NgayBatDau != null)
            {
                dk.NgayKetThuc = dk.NgayBatDau.Value.AddDays(Convert.ToDouble(tgh));
            }
            kh.SoHocVien++;
            dbContext.Update(dk);
            dbContext.SaveChanges();
            dbContext.KhoaHocs.Update(kh);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Cập nhật đăng ký học thành công", converter.EntityToDTO(dk));
        }

        private string DinhDangHoTen(string fullname)
        {
            string[] namepart = fullname.Split(' ');
            if (namepart.Length == 1)
            {
                return fullname;
            }
            for (int i = 0; i < namepart.Length; i++)
            {
                namepart[i] = char.ToUpper(namepart[i][0]) + namepart[i].Substring(1).ToLower();
            }
            string result = string.Join(" ", namepart);
            return result;
        }

        public ResponseObject<DataResponse_DangKyHoc> ThemDangKy(Request_ThemDangKyHoc request, int tkId)
        {
            //if(dbContext.DangKyHocs.Any(x => x.HocVIenId == request.HocVienId && x.KhoaHocId == request.KhoaHocId))
            //{
            //    return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Học viên đã đăng ký khóa học này", null);
            //}
            DangKyHoc dk = new DangKyHoc();
            dk.KhoaHocId = request.KhoaHocId;
            dk.NgayDangKy = DateTime.Now;
            dk.TinhTrangHocId = 1;
            dk.TaiKhoanId = tkId;
            dbContext.Add(dk);
            dbContext.SaveChanges();
            
            return responseObject.ResponseSuccess("Thêm đăng ký học thành công!", converter.EntityToDTO(dk));
        }

        public ResponseObject<DataResponse_DangKyHoc> XoaDangKy(int id)
        {
            if(dbContext.DangKyHocs.Any(x => x.Id == id))
            {
                var dk = dbContext.DangKyHocs.Find(id);
                dbContext.Remove(dk);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa đăng ký học thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Đăng ký học không tồn tại", null);
        }
    }
}
