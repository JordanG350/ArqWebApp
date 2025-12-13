using ArqWebApp.Core.Crud.Models;

namespace ArqWebApp.Core.Crud.Interfaces
{
    public interface IArqWebAppCrud
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);
    }
}
