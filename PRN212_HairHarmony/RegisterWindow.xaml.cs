using HairHarmony_BusinessObject;
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

namespace PRN212_HairHarmony
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBackLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow login = new LoginWindow();
            login.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> role = new List<string>();
            role.Add("Stylist");
            role.Add("Member");
            role.Add("Manager");
            this.cmbRole.ItemsSource = role;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!txtConfirmPassword.Password.Equals(txtPassword.Password))
            {
                MessageBox.Show("Confirm password is incorrect");
                return;
            }
            
            int role = 0;
            Account account = new Account();
            account.Password = txtPassword.Password;
            account.Email  = txtEmail.Text;
            account.AccountId = txtUsername.Text;
            account.Phone = txtPhoneNumber.Text;
            if (cmbRole.SelectedValue.Equals("Stylist")){
                role = 1;
            } else if (cmbRole.SelectedValue.Equals("Member"))
            {
                role = 2;
            }
            else { role = 3; }
            
        }
    }
}
