using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.Services.Interfaces;

namespace QLKhoaHoc_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanServices taiKhoanServices;

        public TaiKhoanController(ITaiKhoanServices taiKhoanServices)
        {
            this.taiKhoanServices = taiKhoanServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(taiKhoanServices.GetAll());
        }

        [HttpPost("DangKy")]
        public IActionResult ThemTaiKhoan([FromForm]Request_ThemTaiKhoan request)
        {
            return Ok(taiKhoanServices.ThemTaiKhoan(request));
        }

        [HttpPost("DangNhap")]
        public IActionResult Login(Request_Login request)
        {
            return Ok(taiKhoanServices.Login(request));
        }

        [HttpPut("CapNhatThongTinTaiKhoan")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult SuaTaiKhoan(Request_ThemTaiKhoan request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(taiKhoanServices.SuaTaiKhoan(request, id));
        }
        [HttpDelete("XoaTaiKhoan")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaTaiKhoan(int id)
        {
            return Ok(taiKhoanServices.XoaTaiKhoan(id));
        }
    }
}
