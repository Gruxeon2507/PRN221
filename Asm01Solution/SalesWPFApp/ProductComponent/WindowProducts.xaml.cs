using BusinessObject.Models;
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

        public Product GetInfor()
        {
            try
            {
                Product product = new Product {
                    ProductName = txtName.Text,
                    CategoryId = Int32.Parse(txtCategory.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = Decimal.Parse(txtPrice.Text),
                    UnitsInStock = Int32.Parse(txtUnit.Text)
                };
                if (txtId.Text != "")
                {
                    product.ProductId = Int32.Parse(txtId.Text);
                }
                return product;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private void LoadProduct(object sender, RoutedEventArgs e)
        {
            Load_data();
            myPopup.IsOpen = true;

        }

        private void InsertProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                    InsertProduct insertProduct = new InsertProduct(_productRepository, _memberRepository, _orderRepository);
                    insertProduct.Closed += ReloadData;
                    insertProduct.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button updateButton && updateButton.DataContext is Product productToUpdate)
                {
                    UpdateProduct updateProduct = new UpdateProduct(_productRepository,_memberRepository,_orderRepository,productToUpdate);
                    updateProduct.Closed += ReloadData;
                    updateProduct.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReloadData(object sender, EventArgs e)
        {
            Load_data();
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                if(sender is Button deleteButton && deleteButton.DataContext is Product productToDelete)
                {
                    _productRepository.DeleteProduct(productToDelete);
                    Load_data();
                    MessageBox.Show("Delete Product completed", "Delete Product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product is existed in a order");
            }
        }

        private void ClearProduct(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtCategory.Text = "";
            txtPrice.Text = "";
            txtUnit.Text = "";    
            txtId.Text = "";  
            txtWeight.Text = "";
        }

        private void SearchById(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = txtId.Text;
                if (id != "")
                {
                    Product p = _productRepository.GetProductById(Int32.Parse(id));
                    if (p != null)
                    {
                        List<Product> list = new List<Product> { p };
                        ListView.ItemsSource = list;
                    }
                    else
                    {
                        MessageBox.Show("Product Is Not Exist");
                        Load_data();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please Input Id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchByPrice(object sender, RoutedEventArgs e)
        {
            try
            {
                string price = txtPrice.Text;
                if (price != "")
                {
                    ListView.ItemsSource = _productRepository.GetProductsByPrice(decimal.Parse(price));
                }
                else
                {
                    MessageBox.Show("Please Input Price");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchByUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                string unit = txtUnit.Text;
                if (unit != "")
                {
                    ListView.ItemsSource = _productRepository.GetProductsByQuantity(Int32.Parse(unit));
                }
                else
                {
                    MessageBox.Show("Please Input Unit In Stock");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderNav(object sender, RoutedEventArgs e)
        {
            WindowOrders windowOrders = new WindowOrders(_productRepository, _memberRepository, _orderRepository);
            windowOrders.Show();
            this.Close();
        }

        private void MemberNav(object sender, RoutedEventArgs e)
        {
            WindowMembers windowMembers = new WindowMembers(_productRepository, _memberRepository, _orderRepository);
            windowMembers.Show();
            this.Close();
        }

        private void LoginNav(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin(_productRepository,_memberRepository,_orderRepository);
            windowLogin.Show();
            this.Close();
        }
        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = false;
        }
    }
}
