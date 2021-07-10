using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(userTypeInput.SelectedIndex == 0) 
            {
                Window managerWindow = new ManagerView();
                managerWindow.Show();
                this.Close();
            } else if (userTypeInput.SelectedIndex == 2)
            {
                Window memberWindow = new MemberView();
                memberWindow.Show();
                this.Close();
            } else if (userTypeInput.SelectedIndex == 1)
            {
                
                Window employeeWindow = new EmployeeView();
                employeeWindow.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Window signUpWindow = new SignUp();
            signUpWindow.Show();
            this.Close();
        }
    }
}
