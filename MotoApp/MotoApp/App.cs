using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp
{
    internal class App : IApp
    {
        private readonly IRepository<Employee> _employeesRepository;

        public App(IRepository<Employee> employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public void Run()
        {
            Console.WriteLine("Start in Run() method");

            var employees = new[]
            {
              new Employee {FirstName = "Ewa"},
              new Employee {FirstName = "Piotr"},
              new Employee {FirstName = "Adam"}
             };

            foreach (var employee in employees)
            {
                _employeesRepository.Add(employee);
            }

            _employeesRepository.Save();

            //reading
            var items = _employeesRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
