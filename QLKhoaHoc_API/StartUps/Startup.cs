using Microsoft.AspNetCore.Builder;
using QLKhoaHoc_API.Entities;
using QLKhoaHoc_API.Services.Implements;

namespace QLKhoaHoc_API.StartUps
{
    public class Startup
    {
        private readonly TaiKhoanServices taiKhoanServices;

        public Startup(TaiKhoanServices taiKhoanServices)
        {
            this.taiKhoanServices = taiKhoanServices;
        }

        public void Configure(IApplicationBuilder app)
        {
            DangKyHoc dkh = new DangKyHoc();
            if(DateTime.Now > dkh.NgayKetThuc)
            {
                dkh.TinhTrangHocId = 3;
            }
        }
    }
}
