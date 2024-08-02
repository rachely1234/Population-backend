using Microsoft.EntityFrameworkCore;
using Models.Model;
using Webapi.Controllers;
using AutoMapper;
using DAL.Interface;
using DAL.Dtos;
using DAL.Data;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(op =>
{
    op.AddPolicy(MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// הגדרת ה-DbContext הנכונה
builder.Services.AddDbContext<ProjectCotext>(op => op.UseSqlServer("Data Source=DESKTOP-SI8MC0H;Initial Catalog=AmericalTable;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True;"));

// הגדרת שירותים נוספים
builder.Services.AddScoped<IPopulation, PopulationData>();
builder.Services.AddScoped<PopulationData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
