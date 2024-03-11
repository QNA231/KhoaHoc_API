using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKhoaHoc_API.PayLoads.DataRequests;
using QLKhoaHoc_API.Services.Implements;
using QLKhoaHoc_API.Services.Interfaces;

namespace QLKhoaHoc_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiKhoaHocController : ControllerBase
    {
        private readonly ILoaiKhoaHocServices _loaiKhoaHocServices;
        public LoaiKhoaHocController(ILoaiKhoaHocServices loaiKhoaHocServices)
        {
            _loaiKhoaHocServices = loaiKhoaHocServices;
        }

        [HttpPost("ThemLoaiKhoaHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request)
        {
            return Ok(_loaiKhoaHocServices.ThemLoaiKhoaHoc(request));
        }
        [HttpPut("CapNhatLoaiKhoaHoc")]
        [Authorize(Roles = "Admin")] 
        public IActionResult CapNhatLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request_ThemLoaiKhoaHoc, int id)
        {
            return Ok(_loaiKhoaHocServices.SuaLoaiKhoaHoc(request_ThemLoaiKhoaHoc, id));
        }
        [HttpDelete("XoaLoaiKhoaHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaLoaiKhoaHoc([FromQuery]Request_XoaLoaiKhoaHoc request)
        {
            return Ok(_loaiKhoaHocServices.XoaLoaiKhoaHoc(request));
        }
    }
}
