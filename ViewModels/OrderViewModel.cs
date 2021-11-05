using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModels
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal FinalTotal { get; set; }

        public IEnumerable<OrderDetailViewModel> ListOfOrderDetailViewModels { get; set; }
    }
}