using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public WindowProducts(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
            Load_data();
        }
        private void Load_data()
        {
            ListView.ItemsSource = _productRepository.GetAllProducts();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadProduct(object sender, RoutedEventArgs e)
        {

        }

        private void InsertProduct(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {

        }

        private void ClearProduct(object sender, RoutedEventArgs e)
        {

        }

        private void SearchById(object sender, RoutedEventArgs e)
        {

        }

        private void SearchByPrice(object sender, RoutedEventArgs e)
        {

        }

        private void SearchByUnit(object sender, RoutedEventArgs e)
        {

        }
    }
}
