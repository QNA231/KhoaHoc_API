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
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHocServices _khoaHocServices;

        public KhoaHocController(IKhoaHocServices khoaHocServices)
        {
            _khoaHocServices = khoaHocServices;
        }
        [HttpGet]
        public IActionResult GetKhoaHoc(string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(_khoaHocServices.PhanTrangKhoaHoc(keyword, pagination));
        }
        [HttpPost("ThemKhoaHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemKhoaHoc(Request_KhoaHoc request, int lkhId)
        {
            return Ok(_khoaHocServices.ThemKhoaHoc(request, lkhId));
        }

        [HttpPut("CapNhatKhoaHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult SuaKhoaHoc(Request_KhoaHoc request, int khId)
        {
            return Ok(_khoaHocServices.SuaKhoaHoc(request, khId));
        }
        [HttpDelete("XoaKhoaHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaKhoaHoc(int khId)
        {
            return Ok(_khoaHocServices.XoaKhoaHoc(khId));
        }
    }
}
