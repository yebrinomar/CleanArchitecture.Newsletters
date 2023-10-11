
using Api.Endpoints;
using Application.Articles.CreateArticle;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                typeof(CreateArticleCommand).Assembly,
                typeof(ApplicationDbContext).Assembly));

            builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

            builder.Services.AddDbContext<ApplicationDbContext>(o =>
                o.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapArticlesEndpoints();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}