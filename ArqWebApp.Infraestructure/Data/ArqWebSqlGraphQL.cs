using ArqWebApp.Api.Data;
using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Core.Crud.Models;
using ArqWebApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArqWebApp.Infraestructure.Data
{
    public class ArqWebSqlGraphQL : IArqWebAppCrudGraphQL
    {
        private readonly AppDbContext _context;

        public ArqWebSqlGraphQL(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.product;
        }
        public async Task<Product> Create(Product product)
        {
            if (product.Price <= 0)
                throw new DomainException("El precio debe ser mayor a cero");

            _context.product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product> Update(Product product)
        {
            var existing = await _context.product.FindAsync(product.Id);
            if (existing == null)
                throw new NotFoundException("Producto no encontrado");

            existing.Name = product.Name;
            existing.Price = product.Price;

            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> Delete(int id)
        {
            var product = await _context.product.FindAsync(id);
            if (product == null)
                throw new NotFoundException("Producto no encontrado");

            _context.product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
