using ArqWebApp.Api.Data;
using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Core.Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqWebApp.Infraestructure.Data
{
    public class ArqWebAppSql : IArqWebAppSql
    {
        private readonly AppDbContext _context;

        public ArqWebAppSql(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cars>> GetAllAsync() =>
            await _context.cars.ToListAsync();

        public async Task<Cars> GetByIdAsync(int id) =>
            await _context.cars.FindAsync(id);

        public async Task<Cars> AddAsync(Cars cars)
        {
            _context.cars.Add(cars);
            await _context.SaveChangesAsync();
            return cars;
        }

        public async Task<Cars> UpdateAsync(Cars cars)
        {
            _context.cars.Update(cars);
            await _context.SaveChangesAsync();
            return cars;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.cars.FindAsync(id);
            if (entity == null) return false;

            _context.cars.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
