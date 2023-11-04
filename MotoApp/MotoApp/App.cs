using MotoApp.Components.CsvReader;
using System.Xml.Linq;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;

        public App(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public void Run()
        {
            CreateXml();
            QueryXml();
        }

        private void QueryXml()
        {
            var document = XDocument.Load("fuel.xml");
            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x => x.Attribute("Manufacturer")?.Value=="BMW")
                .Select(x => x.Attribute("Name")?.Value);

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private void CreateXml()
        {
            var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

            var document = new XDocument();
            var records = new XElement("Cars", cars
                .Select(x =>
                new XElement("Car",
                new XAttribute("Name", x.Name),
                new XAttribute("Combined", x.Combined),
                new XAttribute("Manufacturer", x.Manufacturer)
                )
                ));
            document.Add(records);
            document.Save("fuel.xml");
        }


        private void GroupByJoin()
        {
            var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturer.csv");
            var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

            var groups = cars
                 .GroupBy(x => x.Manufacturer)
                 .Select(g => new
                 {
                     Name = g.Key,
                     Max = g.Max(c => c.Combined),
                     Average = g.Average(c => c.Combined)
                 })
                 .OrderBy(x => x.Average);

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Name}");
                Console.WriteLine($"\t Max: {group.Max}");
                Console.WriteLine($"\t Average:{group.Average}");
            }

            var carsInCountry = cars.Join(
                manufacturers,
                x => x.Manufacturer,
                x => x.Name,
                (car, manufacturer) =>
                    new
                    {
                        manufacturer.Country,
                        car.Name,
                        car.Combined
                    })
                .OrderByDescending(x => x.Combined)
                .ThenBy(x => x.Name);

            foreach (var car in carsInCountry)
            {
                Console.WriteLine($"Country: {car.Country}");
                Console.WriteLine($"\t Name: {car.Name}");
                Console.WriteLine($"\t Combined:{car.Combined}");
            }
        }
    }
}
