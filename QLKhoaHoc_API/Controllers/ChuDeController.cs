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
    public class ChuDeController : ControllerBase
    {
        private readonly IChuDeServices chuDeServices;

        public ChuDeController(IChuDeServices chuDeServices)
        {
            this.chuDeServices = chuDeServices;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDsChuDe(string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(chuDeServices.PhanTrangChuDe(keyword, pagination));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(chuDeServices.GetAll());
        }

        [HttpPost("ThemChuDe")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemChuDe(Request_ChuDe request)
        {
            return Ok(chuDeServices.ThemChuDe(request));
        }

        [HttpPut("CapNhatChuDe")]
        [Authorize(Roles = "Admin")]
        public IActionResult SuaChuDe(Request_ChuDe request, int id)
        {
            return Ok(chuDeServices.SuaChuDe(request, id));
        }

        [HttpDelete("XoaChuDe")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaChuDe(int cdId)
        {
            return Ok(chuDeServices.XoaChuDe(cdId));
        }
    }
}
