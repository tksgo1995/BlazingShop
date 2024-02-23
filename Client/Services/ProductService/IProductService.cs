using BlazingShop.Shared;

namespace BlazingShop.Client.Services.ProductService
{
	public interface IProductService
	{
		List<Product> Products { get; set; }
		void LoadProducts();
	}
}
