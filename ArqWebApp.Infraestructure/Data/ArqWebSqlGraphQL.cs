using ArqWebApp.Api.Data;
using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Core.Crud.Models;
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
    }
}
