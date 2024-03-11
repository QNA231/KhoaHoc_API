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
    public class LoaiBaiVietController : ControllerBase
    {
        private readonly ILoaiBaiVietServices loaiBaiVietServices;

        public LoaiBaiVietController(ILoaiBaiVietServices loaiBaiVietServices)
        {
            this.loaiBaiVietServices = loaiBaiVietServices;
        }
        [HttpGet]
        public IActionResult GetDsLoaiBaiViet(string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(loaiBaiVietServices.GetDsLoaiBaiViet(keyword, pagination));
        }

        [HttpPost("ThemLoaiBaiViet")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemLoaiBaiViet(Request_LoaiBaiViet request)
        {
            return Ok(loaiBaiVietServices.ThemLoaiBaiViet(request));
        }

        [HttpPut("CapNhatLoaiBaiViet")]
        [Authorize(Roles = "Admin")]
        public IActionResult SuaLoaiBaiViet(Request_LoaiBaiViet request, int id)
        {
            return Ok(loaiBaiVietServices.SuaLoaiBaiViet(request, id));
        }

        [HttpDelete("XoaLoaiBaiViet")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaLoaiBaiViet(int id)
        {
            return Ok(loaiBaiVietServices.XoaLoaiBaiViet(id));
        }
    }
}
