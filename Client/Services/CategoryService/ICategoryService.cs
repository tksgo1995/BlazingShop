using BlazingShop.Shared;

namespace BlazingShop.Client.Services.CategoryService
{
	public interface ICategoryService
	{
		public List<Category> Categories { get; set; }

		Task LoadCategories();
	}
}
