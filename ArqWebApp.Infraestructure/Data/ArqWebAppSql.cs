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

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.product.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) =>
            await _context.product.FindAsync(id);

        public async Task<Product> AddAsync(Product product)
        {
            _context.product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.product.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.product.FindAsync(id);
            if (entity == null) return false;

            _context.product.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
