using System;
using System.Text.Json.Serialization;
using Bookstore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Models
{
    public class SessionCart:Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart basket = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book bok, int qty)
        {
            base.AddItem(bok, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Book bok)
        {
            base.RemoveItem(bok);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
