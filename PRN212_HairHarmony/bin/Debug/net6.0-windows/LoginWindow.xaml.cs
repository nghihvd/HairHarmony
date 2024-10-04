﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HairHarmony_BusinessObject;
using HairHarmony_Repository;
using HairHarmony_Services;

namespace PRN212_HairHarmony
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IAccountService iAccountServ;

        public LoginWindow()
        {
            InitializeComponent();
            iAccountServ = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Account account = iAccountServ.getAccountByID(txtUsername.Text.Trim());
            if (!account.AccountId.Equals(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Account not exist");
            }
            if (account != null && account.Password.Equals(txtPassword.Password))
            {
                this.Hide();
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();

            }
            else 
            {
                MessageBox.Show("Wrong Password, Sorry !");
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegis_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterWindow regis = new RegisterWindow();
            regis.Show();
        }
    }
}