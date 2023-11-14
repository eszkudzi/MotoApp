using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<MotoAppDbContext>(options => options
.UseSqlServer("Data Source=DESKTOP-VC0LUU3\\SQLEXPRESS;Initial Catalog=\"MotoAppStorage\";Integrated Security=True;Encrypt=False"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();