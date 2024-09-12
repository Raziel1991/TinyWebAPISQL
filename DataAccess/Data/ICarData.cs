using DataAccess.Models;

namespace DataAccess.Data;
public interface ICarData
{
    Task DeleteCar(int id);
    Task<CarModel?> GetCar(int id);
    Task<IEnumerable<CarModel>> GetCars();
    Task InsertCar(CarModel car);
    Task UpdateCar(CarModel car);
}