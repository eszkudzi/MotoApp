using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Entities;
using MotoApp.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();