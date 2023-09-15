using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Data;

var sqlRepository = new SqlRepository(new MotoAppDbContext());

sqlRepository.Add(new Employee { FirstName = "Ewa" });
sqlRepository.Add(new Employee { FirstName = "Piotr" });
sqlRepository.Add(new Employee { FirstName = "Adam" });

sqlRepository.Save();

var emp = sqlRepository.GetById(1);
Console.WriteLine(emp.ToString());

