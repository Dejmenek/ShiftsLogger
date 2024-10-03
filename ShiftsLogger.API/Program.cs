using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ShiftsLogger.API.Configuration;
using ShiftsLogger.API.Data;
using ShiftsLogger.API.Data.Interfaces;
using ShiftsLogger.API.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache();
builder.Services.Configure<CachingSettings>(builder.Configuration.GetSection("CachingSettings"));
builder.Services.AddControllers();
builder.Services.AddDbContext<ShiftsContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ShiftsDb"));
});
builder.Services.AddScoped<IEmployeesRepository>(provider =>
{
    var context = provider.GetService<ShiftsContext>();
    var cache = provider.GetService<IMemoryCache>();
    var cachingSettings = provider.GetRequiredService<IOptions<CachingSettings>>();

    return new CachingEmployeesRepository(
        cachingSettings,
        new EmployeesRepository(context),
        cache
        );
});
builder.Services.AddScoped<IShiftsRepository, ShiftsRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});
builder.Services.AddControllersWithViews(options => options.SuppressAsyncSuffixInActionNames = false);

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
