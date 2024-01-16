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

namespace SalesWPFApp.Member
{
    /// <summary>
    /// Interaction logic for UpdateMember.xaml
    /// </summary>
    public partial class UpdateMember : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private BusinessObject.Models.Member _member;
        public UpdateMember(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, BusinessObject.Models.Member member)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _member = member;
            InitializeComponent();
            txtCity.Text=member.City;
            txtCompany.Text=member.CompanyName;
            txtCountry.Text=member.Country;
            txtEmail.Text=member.Email;
            txtId.Text=member.MemberId.ToString();
            txtPassword.Text=member.Password;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void UpdateMembers(object sender, RoutedEventArgs e)
        {
            try
            {
                var member = GetInfor();
                if (member != null)
                {
                    _memberRepository.UpdateMember(member);
                    MessageBox.Show("Update Member completed", "Update Member");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
