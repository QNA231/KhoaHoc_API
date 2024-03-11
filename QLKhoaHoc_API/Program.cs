using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QLKhoaHoc_API.PayLoads.Converters;
using QLKhoaHoc_API.PayLoads.DataResponses;
using QLKhoaHoc_API.PayLoads.Responses;
using QLKhoaHoc_API.Services.Implements;
using QLKhoaHoc_API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILoaiKhoaHocServices, LoaiKhoaHocServices>();
builder.Services.AddSingleton<LoaiKhoaHocConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_LoaiKhoaHoc>>();

builder.Services.AddScoped<IKhoaHocServices, KhoaHocServices>();
builder.Services.AddSingleton<KhoaHocConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_KhoaHoc>>();

builder.Services.AddScoped<ILoaiBaiVietServices, LoaiBaiVietServices>();
builder.Services.AddSingleton<LoaiBaiVIetConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_LoaiBaiViet>>();

builder.Services.AddScoped<IBaiVietServices, BaiVietServices>();
builder.Services.AddSingleton<BaiVietConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_BaiViet>>();

builder.Services.AddScoped<IChuDeServices, ChuDeServices>();
builder.Services.AddSingleton<ChuDeConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_ChuDe>>();

builder.Services.AddScoped<ITinhTrangHocServices, TinhTrangHocServices>();
builder.Services.AddSingleton<TinhTrangHocConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_TinhTrangHoc>>();

builder.Services.AddScoped<ITaiKhoanServices, TaiKhoanServices>();
builder.Services.AddSingleton<TaiKhoanConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_TaiKhoan>>();

builder.Services.AddScoped<IQuyenHanServices, QuyenHanServices>();
builder.Services.AddSingleton<QuyenHanConverter>();
builder.Services.AddSingleton<ResponseObject<DataRespone_QuyenHan>>();

builder.Services.AddScoped<IHocVienServices, HocVienServices>();
builder.Services.AddSingleton<HocVienConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_HocVien>>();

builder.Services.AddScoped<IDangKyHocServices, DangKyHocServices>();
builder.Services.AddSingleton<DangKyHocConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponse_DangKyHoc>>();

builder.Services.AddSingleton<ResponseObject<DataResponse_Token>>();

builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Auth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Làm theo mẫu này. Ví dụ: Bearer {Token}",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretKey").Value)),
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
