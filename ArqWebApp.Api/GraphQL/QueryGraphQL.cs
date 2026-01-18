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
    }
}
