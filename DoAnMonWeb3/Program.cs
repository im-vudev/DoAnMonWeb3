
using DoAnMonWeb3.Models;
using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace DoAnMonWeb3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(
                option => option.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue; // Đặt giới hạn này là MaxValue
            });


            builder.Services.AddTransient<DayTroService>();
            builder.Services.AddTransient<DichVuService>();
            builder.Services.AddTransient<DichVuSuDungService>();
            builder.Services.AddTransient<DienNuocService>();
            builder.Services.AddTransient<HoaDonService>();
            builder.Services.AddTransient<LoaiPhongService>();
            builder.Services.AddTransient<NguoiThueService>();
            builder.Services.AddTransient<PhongService>();
            builder.Services.AddTransient<TaikhoanNguoiDungService>();
            builder.Services.AddTransient<TaiKhoanService>();
            builder.Services.AddTransient<ThongBaoService>();
            builder.Services.AddTransient<ThuePhongService>();


            //builder.Services.AddSingleton<IWebHostEnvironment>(env => new WebHostEnvironment());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(proliey => proliey.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials());
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseCors("AllowReactApp");
            app.MapControllers();

            app.Run();
        }
    }
}