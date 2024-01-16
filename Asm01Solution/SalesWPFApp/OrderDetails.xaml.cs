using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private Order _order;
        public OrderDetails(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, Order order)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _order = order;
            InitializeComponent();
            txtFreight.Text=_order.Freight.ToString();
            txtId.Text= _order.OrderId.ToString();
            txtMemberId.Text=_order.MemberId.ToString();
            dtRequriedDate.SelectedDate=_order.RequiredDate;
            dtOrderDate.SelectedDate=_order.ShippedDate;
            dtRequriedDate.SelectedDate=_order.RequiredDate;

        }
    }
}
