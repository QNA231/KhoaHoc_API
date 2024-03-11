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
    public class DangKyHocController : ControllerBase
    {
        private readonly IDangKyHocServices dangKyHocServices;

        public DangKyHocController(IDangKyHocServices dangKyHocServices)
        {
            this.dangKyHocServices = dangKyHocServices;
        }
        [HttpGet]
        public IActionResult GetDsKhoaHoc([FromQuery] Pagination pagination)
        {
            return Ok(dangKyHocServices.PhanTrangDangKy(pagination));
        }

        [HttpPost("ThemDangKyHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ThemDangKyHoc([FromBody] Request_ThemDangKyHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(dangKyHocServices.ThemDangKy(request, id));
        }

        [HttpPut("CapNhatDangKyHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult SuaDangKyHoc([FromQuery] Request_DangKyHoc request, [FromQuery] Request_HocVien request1, [FromQuery] int dkId)
        {
            return Ok(dangKyHocServices.SuaDangKy(request, request1, dkId));
        }

        [HttpDelete("XoaDangKyHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaDangKyHoc(int id)
        {
            return Ok(dangKyHocServices.XoaDangKy(id));
        }
    }
}
