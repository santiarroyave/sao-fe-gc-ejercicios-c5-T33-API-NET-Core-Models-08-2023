using ex01.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ex01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MyDbContext>(p => p.UseInMemoryDatabase("MyDBInMemory"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.MapGet("/dbconexion", async ([FromServices] MyDbContext dbContext) =>
            {
                dbContext.Database.EnsureCreated();
                return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
            });
            // Resultado esperado: "Base de datos en memoria: True"

            app.Run();
        }
    }
}