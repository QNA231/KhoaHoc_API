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
    public class QuyenHanController : ControllerBase
    {
        private readonly IQuyenHanServices quyenHanServices;

        public QuyenHanController(IQuyenHanServices quyenHanServices)
        {
            this.quyenHanServices = quyenHanServices;
        }
        [HttpPost("ThemQuyenHan")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemQuyenHan(Request_QuyenHan request)
        {
            return Ok(quyenHanServices.ThemQuyenHan(request));
        }
        [HttpPut("CapNhatQuyenHan")]
        [Authorize(Roles = "Admin")]
        public IActionResult SuaQuyenHan(Request_QuyenHan request, int id)
        {
            return Ok(quyenHanServices.SuaQuyenHan(request, id));
        }
        [HttpDelete("XoaQuyenHan")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaQuyenHan(int id)
        {
            return Ok(quyenHanServices.XoaQuyenHan(id));
        }
    }
}
