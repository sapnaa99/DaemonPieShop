using DaemonPieShop.Data.DbContexts;
using DaemonPieShop.Data.Interface;
using DaemonPieShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonPieShop.Data.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly DaemonPieShopDbContext _daemonPieShopDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderService(DaemonPieShopDbContext daemonPieShopDbContext, ShoppingCart shoppingCart)
        {
            _daemonPieShopDbContext = daemonPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _daemonPieShopDbContext.Orders.Add(order);

            _daemonPieShopDbContext.SaveChanges();
        }
    }
}
