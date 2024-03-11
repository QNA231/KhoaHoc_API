using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.Services.Interfaces;
using System.Data;

namespace QLKhoaHoc_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhTrangHocController : ControllerBase
    {
        private readonly ITinhTrangHocServices tinhTrangHocServices;

        public TinhTrangHocController(ITinhTrangHocServices tinhTrangHocServices)
        {
            this.tinhTrangHocServices = tinhTrangHocServices;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult HienThiDsTinhTrang()
        {
            return Ok (tinhTrangHocServices.HienThiTinhTrangHoc());
        }
        [HttpPost("ThemTinhTrangHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemTinhTrangHoc(Request_TinhTrangHoc request)
        {
            return Ok(tinhTrangHocServices.ThemTinhTrangHoc(request));
        }
        [HttpPut("SuaTinhTrangHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult SuaTinhTrangHoc(Request_TinhTrangHoc request, int id)
        {
            return Ok(tinhTrangHocServices.SuaTinhTrangHoc(request, id));
        }
        [HttpDelete("XoaTinhTrangHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaTinhTrangHoc(int id)
        {
            return Ok(tinhTrangHocServices.XoaTinhTrangHoc(id));
        }
    }
}
