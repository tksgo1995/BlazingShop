﻿using BlazingShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsByCategory(string categoryUrl);
        Task<Product> GetProduct(int id);
    }
}
