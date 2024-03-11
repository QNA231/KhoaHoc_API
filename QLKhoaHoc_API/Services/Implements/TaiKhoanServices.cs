using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using QLKhoaHoc_API.DataContext;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.Converters;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;
using QLKhoaHoc_API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using BcryptNet = BCrypt.Net.BCrypt;

namespace QLKhoaHoc_API.Services.Implements
{
    public class TaiKhoanServices : ITaiKhoanServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_TaiKhoan> responseObject;
        private readonly TaiKhoanConverter converter;
        private readonly IConfiguration configuration;
        private readonly ResponseObject<DataResponse_Token> responseTokenObject;

        public TaiKhoanServices(ResponseObject<DataResponse_TaiKhoan> responseObject, TaiKhoanConverter converter, IConfiguration configuration, ResponseObject<DataResponse_Token> responseTokenObject)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
            this.configuration = configuration;
            this.responseTokenObject = responseTokenObject;
        }


        public PageResult<TaiKhoan> GetDsTaiKhoan(string? keyword, Pagination pagination)
        {
            var lstTK = dbContext.TaiKhoans.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                lstTK = lstTK.Where(x => x.TenNguoiDung == keyword || x.TajKhoan == keyword);
            }
            var result = PageResult<TaiKhoan>.ToPageResult(pagination, lstTK);
            pagination.TotalCount = lstTK.Count();
            return new PageResult<TaiKhoan>(pagination, result);
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var item  = RandomNumberGenerator.Create())
            {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        public DataResponse_Token GenerateAccessToken(TaiKhoan taiKhoan)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretKey").Value);
            var role = dbContext.QuyenHans.SingleOrDefault(x => x.Id == taiKhoan.QuyenHanId);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", taiKhoan.Id.ToString()),
                    new Claim("TenQuyen", role.TenQuyenHan),
                    new Claim(ClaimTypes.Role, role.TenQuyenHan),
                }),
                Expires = DateTime.Now.AddDays(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = jwtTokenHandle.CreateToken(tokenDesc);
            var accessToken = jwtTokenHandle.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            RefreshToken rf = new RefreshToken
            {
                Token = refreshToken,
                ExpiredTime = DateTime.Now.AddDays(1),
                TaiKhoanId = taiKhoan.Id,
            };
            dbContext.RefreshTokens.Add(rf);
            dbContext.SaveChanges();
            DataResponse_Token result = new DataResponse_Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            return result;
        }

        public DataResponse_Token RenewAccessToken(Request_RenewAccessToken request)
        {
            throw new NotImplementedException();
        }

        public ResponseObject<DataResponse_TaiKhoan> ThemTaiKhoan(Request_ThemTaiKhoan request)
        {
            if(string.IsNullOrWhiteSpace(request.TenNguoiDung) || string.IsNullOrWhiteSpace(request.TajKhoan) || string.IsNullOrWhiteSpace(request.MatKhau))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
            }
            if(dbContext.TaiKhoans.Any(x => x.TajKhoan == request.TajKhoan))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên tài khoản đã tồn tại", null);
            }
            TaiKhoan tk = new TaiKhoan();
            tk.TenNguoiDung = request.TenNguoiDung;
            tk.TajKhoan = request.TajKhoan;
            tk.MatKhau = BcryptNet.HashPassword(request.MatKhau);
            if (!CheckPass(tk.MatKhau))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu phải có cả chữ số và kí tự đặc biệt", null);
            }
            tk.QuyenHanId = 2;
            dbContext.Add(tk);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Thêm tài khoản thành công", converter.EntityToDTO(tk));
        }

        private bool CheckPass(string pass)
        {
            bool coSo = false;
            bool coKiTu = false;
            foreach(char c in pass)
            {
                if (char.IsDigit(c))
                {
                    coSo = true;
                }else if(char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    coKiTu = true;
                }
            }
            return coSo && coKiTu;
        }

        public ResponseObject<DataResponse_TaiKhoan> SuaTaiKhoan(Request_ThemTaiKhoan request, int id)
        {
            if(dbContext.TaiKhoans.Any(x => x.Id == id)){
                if (string.IsNullOrWhiteSpace(request.TenNguoiDung) || string.IsNullOrWhiteSpace(request.TajKhoan) || string.IsNullOrWhiteSpace(request.MatKhau))
                {
                    return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
                }
                if (dbContext.TaiKhoans.Any(x => x.TajKhoan == request.TajKhoan))
                {
                    return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên tài khoản đã tồn tại", null);
                }
                var tk = dbContext.TaiKhoans.Find(id);
                tk.TenNguoiDung = request.TenNguoiDung;
                tk.TajKhoan = request.TajKhoan;
                tk.QuyenHanId = 2;
                dbContext.Add(tk);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Cập nhật tài khoản thành công", converter.EntityToDTO(tk));
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tài khoản không tồn tại", null);
        }

        public ResponseObject<DataResponse_TaiKhoan> XoaTaiKhoan(int id)
        {
            if(dbContext.TaiKhoans.Any(x => x.Id == id))
            {
                var tk = dbContext.TaiKhoans.Find(id);
                dbContext.Remove(tk);
                dbContext.SaveChanges();
                return responseObject.ResponseSuccess("Xóa tài khoản thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tài khoản không tồn tại", null);
        }

        public ResponseObject<DataResponse_Token> Login(Request_Login request)
        {
            var user = dbContext.TaiKhoans.SingleOrDefault(x => x.TajKhoan == request.TenTaiKhoan);
            if(string.IsNullOrWhiteSpace(request.TenTaiKhoan) || string.IsNullOrWhiteSpace(request.MatKhau))
            {
                return responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đủ thông tin", null);
            }
            bool checkPass = BcryptNet.Verify(request.MatKhau, user.MatKhau);
            if (!checkPass)
            {
                return responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu không đúng", null);
            }
            return responseTokenObject.ResponseSuccess("Đăng nhập thành công", GenerateAccessToken(user));
        }

        public IQueryable<DataResponse_TaiKhoan> GetAll()
        {
            var result = dbContext.TaiKhoans.Select(x => converter.EntityToDTO(x));
            return result;
        }
    }
}
