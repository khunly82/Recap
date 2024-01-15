using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Recap.API.Middlewares;
using Recap.BLL.Services;
using Recap.DAL;
using Recap.DAL.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(b => b.AddDefaultPolicy(o => 
    o.AllowAnyHeader()
     .AllowAnyOrigin()
     .AllowAnyMethod()
));
builder.Services.AddDbContext<MyContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("Main")));

builder.Services.AddScoped<CalendarEventService>();
builder.Services.AddScoped<CalendarEventRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next();
//    }
//    catch(ArgumentException ex)
//    {
//        context.Response.StatusCode = 400;
//        context.Response.ContentType = "application/json";
//        await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Error = ex.Message }));
//    }
//});

app.MapControllers();

app.Run();

