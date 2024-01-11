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
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public WindowOrders(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
            Load_data();
        }

        private void MembertNav(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin(_productRepository, _memberRepository, _orderRepository);
            windowLogin.Show();
            this.Close();
        }

        private void OrderNav(object sender, RoutedEventArgs e)
        {
            WindowOrders windowOrders = new WindowOrders(_productRepository, _memberRepository, _orderRepository);
            windowOrders.Show();
            this.Close();
        }

        private void LoginNav(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin(_productRepository, _memberRepository, _orderRepository);
            windowLogin.Show();
            this.Close();
        }

        private void Load_data()
        {
            ListView.ItemsSource = _orderRepository.GetAllOrders();
        }

        public Order GetInfor()
        {
            try
            {
                Order order = new Order
                {
                    OrderDate = dtOrderDate.SelectedDate,
                    RequiredDate = dtRequiredDate.SelectedDate,
                    ShippedDate = dtShippedDate.SelectedDate,
                    Freight = Decimal.Parse(txtFreight.Text),
                    OrderId = Int32.Parse(txtOrderId.Text),
                    MemberId = Int32.Parse(txtMemberId.Text),
                };
               
                return order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void LoadMember(object sender, RoutedEventArgs e)
        {
            Load_data();
        }

        private void InsertMember(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = GetInfor();
                if (order != null)
                {
                    _orderRepository.AddOrder(order);
                    Load_data();
                    MessageBox.Show("Insert Order completed", "Create Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateMember(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = GetInfor();
                if (order != null)
                {
                    _orderRepository.UpdateOrder(order);
                    Load_data();
                    MessageBox.Show("Insert Order completed", "Create Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteMember(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = GetInfor();
                if (order != null)
                {
                    _orderRepository.DeleteOrder(order);
                    Load_data();
                    MessageBox.Show("Insert Order completed", "Create Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchByDate(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? startDate = dtStartDate.SelectedDate;
                DateTime? endDate = dtEndtDate.SelectedDate;
                if (startDate != null && endDate!=null)
                {
                    ListView.ItemsSource = _orderRepository.GetOrdersByDate((DateTime)startDate, (DateTime)endDate);
                }
                else
                {
                    MessageBox.Show("Empty Start Date or End Date");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
