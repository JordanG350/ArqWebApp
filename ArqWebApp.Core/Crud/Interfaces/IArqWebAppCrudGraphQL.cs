using ArqWebApp.Core.Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArqWebApp.Core.Crud.Interfaces
{
    public interface IArqWebAppCrudGraphQL
    {
        IQueryable<Product> GetProducts();
    }
}
