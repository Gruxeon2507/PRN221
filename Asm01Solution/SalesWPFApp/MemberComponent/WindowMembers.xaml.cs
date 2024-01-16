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
using BusinessObject.Models;
using SalesWPFApp.Member;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public WindowMembers(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
            Load_data();

        }
        private void Load_data()
        {
            ListView.ItemsSource = _memberRepository.GetAllMembers();
        }
        private void ProductNav(object sender, RoutedEventArgs e)
        {
            WindowProducts windowProducts = new WindowProducts(_productRepository, _memberRepository, _orderRepository);
            windowProducts.Show();
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

        private void LoadMember(object sender, RoutedEventArgs e)
        {
            Load_data();
        }

        public BusinessObject.Models.Member GetInfor()
        {
            try
            {
                BusinessObject.Models.Member member = new BusinessObject.Models.Member
                {
                    Email = txtEmail.Text,
                    CompanyName = txtCompany.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                if (txtId.Text != "")
                {
                    member.MemberId = Int32.Parse(txtId.Text);
                }
                return member;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private void InsertMember(object sender, RoutedEventArgs e)
        {
            try
            {
                InsertMember insertMember = new InsertMember(_productRepository, _memberRepository, _orderRepository);
                insertMember.Closed += ReloadData;
                insertMember.Show();
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

        private void UpdateMember(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button updateButton && updateButton.DataContext is BusinessObject.Models.Member memberToUpdate)
                {
                    UpdateMember updateMember = new UpdateMember(_productRepository, _memberRepository, _orderRepository, memberToUpdate);
                    updateMember.Closed += ReloadData;
                    updateMember.Show();
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
                if (sender is Button deleteButton && deleteButton.DataContext is BusinessObject.Models.Member memberToDelete)
                {
                    _memberRepository.DeleteMember(memberToDelete);
                    Load_data();
                    MessageBox.Show("Delete member completed", "Delete Member");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Member is existed in an order");
            }
        }
    }
}
