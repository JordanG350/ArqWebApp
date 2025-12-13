using ArqWebApp.Core.Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArqWebApp.Core.Crud.Interfaces
{
    public interface IArqWebAppSql
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
