using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private BusinessObject.Models.Member _member;
        public WindowUser(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, BusinessObject.Models.Member member)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _member = member;
            InitializeComponent();
            Load_data();
        }
        private void Load_data()
        {
            ListView.ItemsSource = _orderRepository.GetOrdersByUser(_member.Email);
        }

        private void OrderDetail(object sender, RoutedEventArgs e)
        {
            if (sender is Button detailButton && detailButton.DataContext is Order orderToView)
            {
                OrderDetails orderDetail = new OrderDetails(_productRepository, _memberRepository, _orderRepository, orderToView);
                orderDetail.Show();
            }
        }
    }
}
