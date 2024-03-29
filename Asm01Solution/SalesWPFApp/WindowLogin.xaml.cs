﻿using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public WindowLogin(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            var admin = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("admin");

            if(email!=null && password != null) {
                if(email.Equals(admin["email"]) && password.Equals(admin["password"]))
                {
                    WindowProducts windowProducts = new WindowProducts(_productRepository, _memberRepository, _orderRepository);
                    windowProducts.Show();
                    this.Close();
                }
                else
                {
                    BusinessObject.Models.Member member = _memberRepository.GetMemberByEmail(email, password);
                    if (member != null)
                    {
                        Hide();
                        WindowUser windowUsers = new WindowUser(_productRepository, _memberRepository, _orderRepository, member);
                        windowUsers.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Wrong Email or Password");
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Email or Password");
            }
        }
    }
}
