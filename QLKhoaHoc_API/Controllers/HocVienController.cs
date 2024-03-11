using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKhoaHoc_API.Paginations;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.Services.Interfaces;
using System.Data;

namespace QLKhoaHoc_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly IHocVienServices hocVienServices;

        public HocVienController(IHocVienServices hocVienServices)
        {
            this.hocVienServices = hocVienServices;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDsHocVien(string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(hocVienServices.GetDsHocVien(keyword, pagination));
        }

        //[HttpPost("ThemHocVien")]
        //public IActionResult ThemHocVien(Request_HocVien request)
        //{
        //    return Ok(hocVienServices.ThemHocVien(request));
        //}

        [HttpPut("CapNhatThongTinHocVien")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult SuaHocVien(Request_HocVien request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(hocVienServices.SuaHocVien(request, id));
        }

        [HttpDelete("XoaHocVien")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaHocVien(int id)
        {
            return Ok(hocVienServices.XoaHocVien(id));
        }
    }
}
