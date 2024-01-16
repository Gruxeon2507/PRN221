using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDetail
    {
        private static OrderDetail instance = null;
        private static readonly object instancelock = new object();
        private OrderDetail() { }
        public static OrderDetail Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetail();
                    }
                    return instance;
                }
            }
        }

        //public IEnumerable<OrderDetail> GetOrderByEmail(int orderId)
        //{
        //    List<OrderDetail> orderList;
        //    try
        //    {
        //        using (var ctx = new Assignment01Context())
        //        {
        //            orderList = ctx.OrderDetails.Where(o => o.OrderId == orderId).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return orderList;
        //}

    }
}
