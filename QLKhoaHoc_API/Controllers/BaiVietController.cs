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
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietServices baiVietServices;

        public BaiVietController(IBaiVietServices baiVietServices)
        {
            this.baiVietServices = baiVietServices;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDsBaiViet(string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(baiVietServices.GetDsBaiViet(keyword, pagination));
        }

        [HttpPost("ThemBaiViet")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemBaiViet(Request_BaiViet request, int cdId)
        {
            return Ok(baiVietServices.ThemBaiViet(request, cdId));
        }

        [HttpPut("CapNhatBaiViet")]
        [Authorize(Roles = "Admin")]
        public IActionResult SuaBaiViet(Request_BaiViet request, int id)
        {
            return Ok(baiVietServices.SuaBaiViet(request, id));
        }

        [HttpDelete("XoaBaiViet")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaBaiViet(int id)
        {
            return Ok(baiVietServices.XoaBaiViet(id));
        }
    }
}
