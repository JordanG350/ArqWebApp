using ArqWebApp.Core.Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArqWebApp.Core.Crud.Interfaces
{
    public interface IArqWebAppSql
    {
        Task<IEnumerable<Cars>> GetAllAsync();
        Task<Cars> GetByIdAsync(int id);
        Task<Cars> AddAsync(Cars cars);
        Task<Cars> UpdateAsync(Cars cars);
        Task<bool> DeleteAsync(int id);
    }
}
