using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp.DataProviders
{
    public class CarProviderBasic : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;
        public CarProviderBasic(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<Car> FilterCars(decimal minPrice)
        {
            var cars = _carsRepository.GetAll();
            var list = new List<Car>();
            foreach (var car in cars)
            {
                if (car.ListPrice > minPrice)
                {
                    list.Add(car);
                }
            }

            return list;
        }

        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            List<string> list = new();
            foreach (var car in cars)
            {
                if (!list.Contains(car.Color))
                {
                    list.Add(car.Color);
                }
            }

            return list;
        }

        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            decimal ret = decimal.MaxValue;
            foreach (var car in cars)
            {
                if (car.ListPrice < ret)
                {
                    ret = car.ListPrice;
                }
            }

            return ret;
        }

        public List<Car> GetSpecificColumns()
        {
            throw new NotImplementedException();
        }

        public string AnonymousClass()
        {
            throw new NotImplementedException();
        }

        public List<Car> OrderByName()
        {
            throw new NotImplementedException();
        }

        public List<Car> OrderByNameDescending()
        {
            throw new NotImplementedException();
        }

        public List<Car> OrderByColorAndName()
        {
            throw new NotImplementedException();
        }

        public List<Car> OrderByColorAndNameDesc()
        {
            throw new NotImplementedException();
        }

        public List<Car> WhereStartsWith(string prefix)
        {
            throw new NotImplementedException();
        }

        public List<Car> WhereStartsWithAndCostIsGreatherThan(string prefix, decimal cost)
        {
            throw new NotImplementedException();
        }

        public List<Car> WhereColorIs(string color)
        {
            throw new NotImplementedException();
        }

        public Car FirstByColor(string color)
        {
            throw new NotImplementedException();
        }

        public Car? FirstOrDefaultByColor(string color)
        {
            throw new NotImplementedException();
        }

        public Car FirstOrDefaultByColorWithDefault(string color)
        {
            throw new NotImplementedException();
        }

        public Car LastByColor(string color)
        {
            throw new NotImplementedException();
        }

        public Car SingleById(int id)
        {
            throw new NotImplementedException();
        }

        public Car? SingleOrDefaultById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> TakeCars(int howMany)
        {
            throw new NotImplementedException();
        }

        public List<Car> TakeCars(Range range)
        {
            throw new NotImplementedException();
        }

        public List<Car> TakeCarsWhileNameStartsWith(string prefix)
        {
            throw new NotImplementedException();
        }

        public List<Car> SkipCars(int howMany)
        {
            throw new NotImplementedException();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            throw new NotImplementedException();
        }

        public List<string> DistinctAllColors()
        {
            throw new NotImplementedException();
        }

        public List<Car> DistinctByColors()
        {
            throw new NotImplementedException();
        }

        public List<Car[]> ChunkCars(int size)
        {
            throw new NotImplementedException();
        }
    }
}
