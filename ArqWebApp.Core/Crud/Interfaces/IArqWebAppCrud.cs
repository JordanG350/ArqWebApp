using ArqWebApp.Core.Crud.Models;

namespace ArqWebApp.Core.Crud.Interfaces
{
    public interface IArqWebAppCrud
    {
        Task<IEnumerable<Cars>> GetAllCars();
        Task<Cars> GetCarById(int id);
        Task<Cars> CreateCar(Cars cars);
        Task<Cars> UpdateCar(int id, Cars cars);
        Task<bool> DeleteCar(int id);
    }
}
