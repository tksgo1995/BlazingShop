using BlazingShop.Shared;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;

namespace BlazingShop.Server.Services.PaymentService
{
	public class PaymentService : IPaymentService
	{
        public PaymentService()
        {
			StripeConfiguration.ApiKey = "";
        }

        public Session CreateCheckoutSession(List<CartItem> cartItems)
		{
			throw new System.NotImplementedException();
		}
	}
}
