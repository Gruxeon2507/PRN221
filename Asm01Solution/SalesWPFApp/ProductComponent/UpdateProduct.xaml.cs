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
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private Product _product;
        public UpdateProduct(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, Product product)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _product = product;
            InitializeComponent();
            txtCategory.Text=product.CategoryId.ToString();
            txtId.Text=product.ProductId.ToString();
            txtName.Text=product.ProductName.ToString();
            txtPrice.Text = product.UnitPrice.ToString();
            txtUnit.Text = product.UnitsInStock.ToString();    
            txtWeight.Text = product.Weight.ToString();
        }
        public Product GetInfor()
        {
            try
            {
                Product product = new Product
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void UpdateProducts(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = GetInfor();
                if (product != null)
                {
                    _productRepository.UpdateProduct(product);
                    MessageBox.Show("Update Product completed", "Update Product");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
