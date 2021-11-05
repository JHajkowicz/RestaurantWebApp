using RestaurantWebApp.Models;
using RestaurantWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.Repositories
{
    public class OrderRepository
    {
        private RestaurantDatabaseEntities objRestaurantDatabaseEntities;
        public OrderRepository()
        {
            objRestaurantDatabaseEntities = new RestaurantDatabaseEntities();
        }

        //zapisywanie w bazie
        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.userID -= objOrderViewModel.UserID;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = string.Format("0:ddmmyyyyhhmmss", DateTime.Now);
            objRestaurantDatabaseEntities.Orders.Add(objOrder);
            objRestaurantDatabaseEntities.SaveChanges();
            int orderID = objOrder.OrderID;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModels)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderID = orderID;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ProductID = item.ProductID;
                objOrderDetail.Total = item.FinalTotal;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;

                Transaction objTransaction = new Transaction();
                objTransaction.ProductID = item.ProductID;
                objTransaction.Quantity = item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;
                objRestaurantDatabaseEntities.Transactions.Add(objTransaction);
                objRestaurantDatabaseEntities.SaveChanges();
            }

            return true;
        }

    }
}