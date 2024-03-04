using BlazingShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazingShop.Client.Services.CategoryService
{
	public interface ICategoryService
	{
		public List<Category> Categories { get; set; }

		Task LoadCategories();
	}
}
