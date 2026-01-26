using ArqWebApp.Api.GraphQL.Inputs;
using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Core.Crud.Models;

namespace ArqWebApp.Api.GraphQL
{
    public class QueryGraphQL
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts(
        [Service] IArqWebAppCrudGraphQL crud)
        {
            return crud.GetProducts();
        }

        public async Task<Product> CreateProduct(
        CreateProductInput input,
        [Service] IArqWebAppCrudGraphQL crud)
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price
            };


            return await crud.Create(product);
        }


        public async Task<Product> UpdateProduct(
        UpdateProductInput input,
        [Service] IArqWebAppCrudGraphQL crud)
        {
            var product = new Product
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Price = input.Price
            };


            return await crud.Update(product);
        }


        public async Task<bool> DeleteProduct(
        int id,
        [Service] IArqWebAppCrudGraphQL crud)
        {
            return await crud.Delete(id);
        }
    }
}
