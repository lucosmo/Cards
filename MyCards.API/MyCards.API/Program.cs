using Microsoft.EntityFrameworkCore;
using MyCards.API.Data;
using MyCards.API.Repositories;

namespace MyCards.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSingleton<ICardRepository, InMemoryCardRepository>();
            builder.Services.AddScoped<ICardRepository, CardRepository>();
            builder.Services.AddScoped<IFileRepository, AzureBlobFileRepository>(_ => new AzureBlobFileRepository(builder.Configuration["StorageConnectionString"]));
            var connectionString = builder.Configuration["ConnectionStrings:MyCardsDb"];
            builder.Services.AddDbContext<MyCardsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

/*
 * dotnet ef migrations add Initial
 * dotnet ef database update
 * */