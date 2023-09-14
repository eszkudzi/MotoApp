using MotoApp.Entities;
using MotoApp.Repositories;

var employeeRepository = new GenericRepository<Employee, Guid>();
employeeRepository.Add(new Employee { FirstName = "Ewa"});
employeeRepository.Add(new Employee { FirstName = "Piotr" });
employeeRepository.Add(new Employee { FirstName = "Adam" });

employeeRepository.Save();

