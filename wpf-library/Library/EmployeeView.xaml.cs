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
using Wpf_library.Domain.Models;
using Wpf_library.EntityFramework.Services;

namespace Library
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
		private readonly Employee activeEmployee;
		private readonly BookDataService bookService = new BookDataService(new Wpf_library.EntityFramework.WpfLibraryDbContextFactory());
		private readonly UserDataService<Member> memberService = new UserDataService<Member>(new Wpf_library.EntityFramework.WpfLibraryDbContextFactory());
		private readonly UserDataService<Employee> employeeService = new UserDataService<Employee>(new Wpf_library.EntityFramework.WpfLibraryDbContextFactory());

        public EmployeeView(Wpf_library.Domain.Models.Employee employee)
        {
			this.activeEmployee = employee;
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
