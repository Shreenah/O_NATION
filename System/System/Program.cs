using Microsoft.EntityFrameworkCore;
using System.Interface;
using System.Models;
using System.Repository;
using Microsoft.EntityFrameworkCore;



namespace System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            //Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
            builder.Services.AddDbContext<O_NATIONContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
            builder.Services.AddTransient<IUsers, UserRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // Add services to the container.

            ////builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

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