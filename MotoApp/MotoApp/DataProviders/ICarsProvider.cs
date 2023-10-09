using MotoApp.Entities;

namespace MotoApp.DataProviders
{
    public interface ICarsProvider
    {
        //other
        List<Car> FilterCars(decimal minPrice);

        //select
        List<string> GetUniqueCarColors();

        decimal GetMinimumPriceOfAllCars();

        List<Car> GetSpecificColumns();

        string AnonymousClass();

        //other by
        List<Car> OrderByName();
        List<Car> OrderByNameDescending();
        List<Car> OrderByColorAndName();
        List<Car> OrderByColorAndNameDesc();

    }
}
