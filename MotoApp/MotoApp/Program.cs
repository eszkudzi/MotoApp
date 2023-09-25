﻿using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

var itemAdded = new ItemAdded<Employee>(EmployeeAdded);
var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), itemAdded);

AddEmployees(employeeRepository);
WriteAllToConsole(employeeRepository);

static void EmployeeAdded(Employee item)
{
    Console.WriteLine($"{item.FirstName} added");
}

static void AddEmployees(IRepository<Employee> repository)
{
    var employees = new[]
    {
        new Employee {FirstName = "Ewa"},
        new Employee {FirstName = "Piotr"},
        new Employee {FirstName = "Adam"}
    };
    repository.AddBatch(employees);
}



static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
