using MotoApp.Entities;
using MotoApp.Repositories;
using System.Text;

namespace MotoApp.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;

        public CarsProvider(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }
        public string AnonymousClass()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new
            {
                Identifier = car.Id,
                ProductName = car.Name,
                ProductType = car.Type
            });
            StringBuilder sb = new(2048);
            foreach (var car in list)
            {
                sb.Append($"Product ID: {car.Identifier}");
                sb.Append($"Product Name: {car.ProductName}");
                sb.Append($"Product Type: {car.ProductType}");
            }
            return sb.ToString();
        }

        public List<Car> FilterCars(decimal minPrice)
        {
            throw new NotImplementedException();
        }

        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            return cars.Select(x => x.ListPrice).Min();
        }

        public List<Car> GetSpecificColumns()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new Car
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type
            }).ToList();

            return list;
        }

        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            var colors = cars.Select(x => x.Color).Distinct().ToList();
            return colors;
        }

        public List<Car> OrderByColorAndName()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.Color).ThenBy(x=>x.Name).ToList();
        }

        public List<Car> OrderByColorAndNameDesc()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(x => x.Color).ThenByDescending(x => x.Name).ToList();
        }

        public List<Car> OrderByName()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.Name).ToList();
        }

        public List<Car> OrderByNameDescending()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(x => x.Name).ToList();
        }
    }
}
