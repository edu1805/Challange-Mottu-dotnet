using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Cp2WebApplication.Infrastructure.Context;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.Repositories;
using Cp2WebApplication.Infrastructure.Mappings;


namespace Cp2WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration["Swagger:Title"] ?? "Cp2 API",
                    Description = (builder.Configuration["Swagger:Description"] ?? "API para gerenciamento de motos no p�tio - ") + DateTime.Now.Year,
                    Contact = new OpenApiContact()
                    {
                        Email = "profthiago.vicco@fiap.com.br",
                        Name = "Thiago Keller"
                    }
                });
            });

            // Banco de dados Oracle
            builder.Services.AddDbContext<Cp2Context>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
            });

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // Exemplo de inje��o de reposit�rio (se estiver usando)
            builder.Services.AddScoped<IRepository<Moto>, Repository<Moto>>();

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

            app.Run();
        }
    }
}
