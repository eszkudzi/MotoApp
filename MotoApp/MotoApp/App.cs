using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;
using MotoApp.Data;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;
        private readonly MotoAppDbContext _motoAppDbContext;

        public App(ICsvReader csvReader, MotoAppDbContext motoAppDbContext)
        {
            _csvReader = csvReader;
            _motoAppDbContext = motoAppDbContext;
            _motoAppDbContext.Database.EnsureCreated();
        }
        public void Run()
        {
            // InsertData();
            // ReadAllCarsFromDb();
            // ReadGroupedlCarsFromDb();

            var cayman = this.ReadFirst("Cayman");
            //cayman.Name = "Mój Samochód";
            //_motoAppDbContext.SaveChanges();

            _motoAppDbContext.Cars.Remove(cayman);
            _motoAppDbContext.SaveChanges();
        }

        public Car? ReadFirst (string name)
        {
            return _motoAppDbContext.Cars.FirstOrDefault(x => x.Name == name);
        }

        public void ReadGroupedlCarsFromDb()
        {
            var groups = _motoAppDbContext
                .Cars
                .GroupBy(x => x.Manufacturer)
                .Select(x => new
                {
                    Name = x.Key,
                    Cars = x.ToList()
                })
                .ToList();

            foreach (var group in groups)
            {
                Console.WriteLine(group.Name);
                Console.WriteLine("========");
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
                Console.WriteLine();
            }
        }

        public void ReadAllCarsFromDb()
        {
            var carsFromDb = _motoAppDbContext.Cars.ToList();
            foreach (var carFromDB in carsFromDb)
            {
                Console.WriteLine($"\t{carFromDB.Name}: {carFromDB.Combined}");
            }
        }

        public void InsertData()
        {
            var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

            foreach (var car in cars)
            {
                _motoAppDbContext.Cars.Add(new Entities.Car()
                {
                    Manufacturer = car.Manufacturer,
                    Name = car.Name,
                    Year = car.Year,
                    City = car.City,
                    Combined = car.Combined,
                    Cylinders = car.Cylinders,
                    Displacement = car.Displacement,
                    Highway = car.Highway
                });
            }

            _motoAppDbContext.SaveChanges();
        }

    }
}
