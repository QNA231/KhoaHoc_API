using Microsoft.EntityFrameworkCore;
using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.DataContext
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChuDe>  ChuDes { get; set; }
        public virtual DbSet<QuyenHan> QuyenHans { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<DangKyHoc> DangKyHocs { get; set; }
        public virtual DbSet<TinhTrangHoc> TinhTrangHocs { get; set; }
        public virtual DbSet<LoaiKhoaHoc> LoaiKhoaHocs { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-1600EKM7\\SQLEXPRESS; Database = QLKhoaHoc_API; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
