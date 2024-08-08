using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShiftsLogger.UI;
using ShiftsLogger.UI.Controllers;
using ShiftsLogger.UI.Data.Interfaces;
using ShiftsLogger.UI.Data.Repositories;
using ShiftsLogger.UI.Services;
using ShiftsLogger.UI.Services.Interfaces;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddSingleton(configuration);
services.AddSingleton<HttpClient>();
services.AddScoped<IUserInteractionService, UserInteractionService>();
services.AddScoped<Menu>();
services.AddScoped<IEmployeeService, EmployeeService>();
services.AddScoped<IShiftService, ShiftService>();
services.AddScoped<IEmployeesRepository, EmployeesRepository>();
services.AddScoped<IShiftsRepository, ShiftsRepository>();
services.AddTransient<ShiftsController>();
services.AddTransient<EmployeesController>();

var serviceProvider = services.BuildServiceProvider();

var start = serviceProvider.GetService<Menu>();

await start.Run();