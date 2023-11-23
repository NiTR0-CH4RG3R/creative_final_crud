using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace creative_final_crud {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Database.CfrDatabase as a service
            builder.Services.AddDbContext<CfrDatabase>( option => option.UseMySQL(
                    builder.Configuration.GetConnectionString("DefaultConnection") ?? ""
                )
            );

            // Enable CORS (Cross-Origin Resource Sharing) headers globally so that the Blazor client (or any other client) web app can access the API
            builder.Services.AddCors( options => {
                options.AddPolicy( "CorsPolicy", builder => {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("CorsPolicy");

            app.Run();
        }
    }
}


