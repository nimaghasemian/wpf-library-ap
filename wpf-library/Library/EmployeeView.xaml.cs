using System;
using System.Collections.Generic;
using System.Linq;
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
using Wpf_library.EntityFramework;
using Wpf_library.EntityFramework.Services;

namespace Library
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
		private readonly Employee activeEmployee;
		private readonly BookDataService bookService = new BookDataService(new WpfLibraryDbContextFactory());
		private readonly UserDataService<Member> memberService = new UserDataService<Member>(new WpfLibraryDbContextFactory());
		private readonly UserDataService<Employee> employeeService = new UserDataService<Employee>(new WpfLibraryDbContextFactory());
		private readonly BookTransactionDataSerivce bookTransactionService = new BookTransactionDataSerivce(new WpfLibraryDbContextFactory());

		private IEnumerable<Book> books;
		private IEnumerable<Member> members;

		public EmployeeView(Employee employee)
        {
			this.activeEmployee = employee;
            InitializeComponent();
        }
		private async void btn_employee_books_Click(object sender, RoutedEventArgs e)
		{
			TabControl_employee.SelectedItem = Tab_employee_books;
			members = await memberService.GetAll();
			usersGrid.ItemsSource = members;
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

        private void TabControl_employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
			books = await bookService.GetAll();
			bookGrid.ItemsSource = books;
		}

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
			members = await memberService.GetAll();
			usersGrid.ItemsSource = members;
		}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
			var lateForSubscribtion = from member in members where (DateTime.Now.Day - member.LastPayDate.Day) > 30 select new { Name = member.Name,Email = member.Email,Phone = member.PhoneNumber, RemainingDays = (DateTime.Now.Day - member.LastPayDate.Day)};
			usersGrid.ItemsSource = lateForSubscribtion;
		}

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
			if(userSearchInput.Text.Trim() == "")
            {
				MessageBox.Show("You should enter a name first");
            }
            else
            {
				var foundUsers = from member in members
								 where (member.Name == userSearchInput.Text.Trim()) select member;

				Member foundUser = foundUsers.First();
			}
        }


        private async void showBorrowedBooks(object sender, RoutedEventArgs e)
        {
			var allBookTransactions = await bookTransactionService.GetAll();
			var currentlyBorrowedBooks = from transaction in allBookTransactions
												  where transaction.RetrunStatus == false
												  select transaction.RentedBook;
			bookGrid.ItemsSource = currentlyBorrowedBooks;
        }
    }
}
