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

namespace wpf_library
{
	/// <summary>
	/// Interaction logic for Employee.xaml
	/// </summary>
	public partial class Employee : Window
	{
		public Employee()
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
			UsersInfoPage usersInfoPage = new UsersInfoPage();
			usersInfoPage.Show();
		}

		private void btn_employee_exit_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}
	}
}
