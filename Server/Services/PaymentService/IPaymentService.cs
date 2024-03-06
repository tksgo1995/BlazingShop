using BlazingShop.Shared;
using Stripe.Checkout;
using System.Collections.Generic;

namespace BlazingShop.Server.Services.PaymentService
{
	public interface IPaymentService
	{
		Session CreateCheckoutSession(List<CartItem> cartItems);
	}
}
