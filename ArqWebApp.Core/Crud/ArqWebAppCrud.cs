using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Core.Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArqWebApp.Core.Crud
{
    public class ArqWebAppCrud : IArqWebAppCrud
    {
        private readonly IArqWebAppSql _repo;

        public ArqWebAppCrud(IArqWebAppSql repo)
        {
            _repo = repo;
        }
        public async Task<Cars> CreateCar(Cars cars)
        {
            return await _repo.AddAsync(cars);
        }

        public async Task<bool> DeleteCar(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Cars>> GetAllCars()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Cars> GetCarById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Cars> UpdateCar(int id, Cars cars)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = cars.Name;
            existing.Year = cars.Year;
            existing.Description = cars.Description;
            existing.Price = cars.Price;

            return await _repo.UpdateAsync(existing);

        }
    }
}
