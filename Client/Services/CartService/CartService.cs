using BlazingShop.Client.Services.ProductService;
using BlazingShop.Shared;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingShop.Client.Services.CartService
{
	public class CartService : ICartService
	{
		private readonly ILocalStorageService _localStorage;
		private readonly IProductService _productService;
		private readonly HttpClient _http;
		private readonly IToastService _toastService;

		public event Action OnChange;

        public CartService(ILocalStorageService localStorage, 
			IToastService toastService, 
			IProductService productService,
			HttpClient http)
        {
			_localStorage = localStorage;
			_productService = productService;
			_http = http;
			_toastService = toastService;
		}

        public async Task AddToCart(CartItem item)
		{
			var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
			if(cart == null)
			{
				cart = new List<CartItem>();
			}

			var sameItem = cart.Find(x => x.ProductId == item.ProductId && x.EditionId == item.EditionId);
			if(sameItem == null)
			{
				cart.Add(item);
			}
			else
			{
				sameItem.Quantity += item.Quantity;
			}

			await _localStorage.SetItemAsync("cart", cart);

			var product = await _productService.GetProduct(item.ProductId);
			_toastService.ShowSuccess(product.Title, "Added to cart:");

			OnChange.Invoke();
		}

		public async Task<List<CartItem>> GetCartItems()
		{
			var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
			if(cart == null)
			{
				return new List<CartItem>();
			}

			return cart;
		}

		public async Task DeleteItem(CartItem item)
		{
			var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
			if(cart == null)
			{
				return;
			}

			var cartItem = cart.Find(x => x.ProductId == item.ProductId && x.EditionId == item.EditionId);
			cart.Remove(cartItem);

			await _localStorage.SetItemAsync("cart", cart);
			OnChange.Invoke();
		}

		public async Task EmptyCart()
		{
			await _localStorage.RemoveItemAsync("cart");
			OnChange.Invoke();
		}

		public async Task<string> Checkout()
		{
			var result = await _http.PostAsJsonAsync("api/payment/checkout", await GetCartItems());
			var url = await result.Content.ReadAsStringAsync();
			return url;
		}
	}
}
