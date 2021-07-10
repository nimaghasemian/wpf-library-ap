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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        public EmployeeView()
        {
            InitializeComponent();
        }
		private void btn_employee_books_Click(object sender, RoutedEventArgs e)
		{
			TabControl_employee.SelectedItem = Tab_employee_books;
		}

		private void btn_employee_users_Click(object sender, RoutedEventArgs e)
		{
			TabControl_employee.SelectedItem = Tab_employee_users;
		}

		private void btn_employee_cart_Click(object sender, RoutedEventArgs e)
		{
			TabControl_employee.SelectedItem = Tab_employee_cart;
		}

		private void btn_employee_editinfo_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_employee_exit_Click(object sender, RoutedEventArgs e)
		{
			Window login = new Login();
			login.Show();
			this.Close();
		}
	}
}
