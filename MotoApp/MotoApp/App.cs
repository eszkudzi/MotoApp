using MotoApp.DataProviders;
using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp
{
    internal class App : IApp
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<Car> _carsRepository;
        private readonly ICarsProvider _carsProvider;


        public App(IRepository<Employee> employeesRepository, IRepository<Car> carsRepository, ICarsProvider carsProvider)
        {
            _employeesRepository = employeesRepository;
            _carsRepository = carsRepository;
            _carsProvider = carsProvider;
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

            //cars
            var cars = GenerateSampleCars();
            foreach (var car in cars)
            {
                _carsRepository.Add(car);
            }

            //carsProviders
            foreach (var car in _carsProvider.FilterCars(1000))
            {
                Console.WriteLine(car);
            }

        }


        public static List<Car> GenerateSampleCars()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = 680,
                    Name = "Car 1",
                    Color = "Black",
                    StandardCost = 1059.31M,
                    ListPrice = 1431.50M,
                    Type = "Audi",
                    NameLength = 1,
                    TotalSales = 10000
                }
            };
        }
    }
}
