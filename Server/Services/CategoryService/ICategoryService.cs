﻿using BlazingShop.Shared;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryByUrl(string categoryUrl);
    }
}
