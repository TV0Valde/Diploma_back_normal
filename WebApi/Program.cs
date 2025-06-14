using Application;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Minio;
using Persistence;
using Persistence.Repository;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://83.222.16.222:8080") // Указываем фронтенд URL
                              .AllowAnyHeader()                     // Разрешаем любые заголовки
                              .AllowAnyMethod()                     // Разрешаем любые HTTP методы
                              .AllowCredentials();                  // Если используются куки или авторизация
                    });
            });


            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddScoped<IBuildingService, BuildingService>();
            builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
            builder.Services.AddScoped<IFormatService, FormatService>();
            builder.Services.AddScoped<IFormatRepository, FormatRepository>();
            builder.Services.AddScoped<IPointsService, PointsService>();
            builder.Services.AddScoped<IPointsRepository, PointsRepository>();
            builder.Services.AddScoped<IPointRecordRepository, PointRecordRepository>();
            builder.Services.AddScoped<IBuildingInfoRepository, BuildingInfoRepository>();
            builder.Services.AddScoped<IBuildingInfoService, BuildingInfoService>();
                 builder.Services.AddScoped<IFileStorageRepository, MinioFileStorageRepository>();
            builder.Services.AddScoped<IPointRecordService, PointRecordService>(); ;
            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

                app.UseSwagger();
                app.UseSwaggerUI();

            app.UseAuthorization();
            app.UseCors("AllowFrontend");
            app.MapControllers();

            app.Run();
        }
    }
}
