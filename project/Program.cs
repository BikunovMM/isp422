using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbIsp422Context>(
    options => options.UseSqlServer(
        "Server= DESKTOP-K6LFJKO ;Database= db_isp422 ;User Id= Sa ;Password= 12345 ;TrustServerCertificate= True ;"));

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISettingsService, SettingsService>();
builder.Services.AddScoped<IFileFormatsService, FileFormatsService>();
builder.Services.AddScoped<IUsingFormatsService, UsingFormatsService>();
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<IConvertationsService, ConvertationsService>();
builder.Services.AddScoped<IConvertationsHistoryService, ConvertationsHistoryService>();
builder.Services.AddScoped<IConvertationParameterService, ConvertationParameterService>();
builder.Services.AddScoped<IConvertationParametersService, ConvertationParametersService>();


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

app.Run();
