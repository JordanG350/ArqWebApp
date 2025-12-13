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
        public async Task<Product> CreateProduct(Product product)
        {
            return await _repo.AddAsync(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;

            return await _repo.UpdateAsync(existing);

        }
    }
}
