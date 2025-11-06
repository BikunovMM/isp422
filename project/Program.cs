using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbIsp422Context>(
    options => options.UseSqlServer(
        //"Server= DESKTOP-K6LFJKO ;Database= db_isp422 ;User Id= sa ;Password= 12345 ;TrustServerCertificate= True ;"
        
        "Server= DESKTOP-K6LFJKO ;Database= db_isp422 ;User Id= sa ;Password= 12345 ;TrustServerCertificate= True ;",
        b => b.MigrationsAssembly("DataAccess")
    )
);

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
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v12",
        Title = " онвертер файлов",
        Description = "≈щкере",
        Contact = new OpenApiContact
        {
            Name = " онтакты: вк, макс",
            Url = new Uri("https://vk.com/id777625246?ysclid=mgglum24ev251840498")
        },
        License = new OpenApiLicense
        {
            Name = "Ћицензи€: MIT\nCopyright <2049> <Misha Bikunov 2006>\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the УSoftwareФ), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED УAS ISФ, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.",
            Url = new Uri("https://rutube.ru/video/ac4ac2f35c35fe2dc78e9a66c48097cb/")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
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

app.Run();
