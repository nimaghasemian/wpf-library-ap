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
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
		private readonly Manager currentManager;
		private readonly BookDataService bookService = new BookDataService(new Wpf_library.EntityFramework.WpfLibraryDbContextFactory());
		private readonly UserDataService<Member> memberService = new UserDataService<Member>(new Wpf_library.EntityFramework.WpfLibraryDbContextFactory());
		private readonly UserDataService<Employee> employeeService = new UserDataService<Employee>(new Wpf_library.EntityFramework.WpfLibraryDbContextFactory());

		public ManagerView(Manager manager)
        {
			this.currentManager = manager;
            InitializeComponent();
        }
		private void btn_manager_employee_Click(object sender, RoutedEventArgs e)
		{
			TabControl_manager.SelectedItem = Tab_manager_employee;
		}

		private void btn_manager_books_Click(object sender, RoutedEventArgs e)
		{
			TabControl_manager.SelectedItem = Tab_manager_books;
		}

		private void btn_manager_cash_Click(object sender, RoutedEventArgs e)
		{
			TabControl_manager.SelectedItem = Tab_manager_cash;
		}

		private void btn_manager_exit_Click(object sender, RoutedEventArgs e)
		{
			Window login = new Login();
			login.Show();
			this.Close();
		}

		private void btn_manager_addemployee_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_manager_addbook_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}

