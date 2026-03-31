using backendTest.Context;
using backendTest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 資料庫連線
var connectionString = builder.Configuration.GetConnectionString("BackendTestContext");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string 'BackendTestContext' not found.");
}
builder.Services.AddDbContext<BackendTestContext>(options => options.UseSqlServer(connectionString));

// Api 註冊
builder.Services.AddScoped<IAcpdService, AcpdService>();

// swagger api 文件
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MyOffice API", Version = "v1" });

    // 讀取 XML 檔案
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
