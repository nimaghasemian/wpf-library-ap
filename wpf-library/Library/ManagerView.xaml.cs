using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
		private readonly Manager currentManager;

		private readonly UserDataService<Employee> employeeService = new UserDataService<Employee>(new WpfLibraryDbContextFactory());
		private readonly BookDataService bookService = new BookDataService(new WpfLibraryDbContextFactory());
		private readonly UserDataService<Manager> managerService = new UserDataService<Manager>(new Wpf_library.EntityFramework.WpfLibraryDbContextFactory());

		private IEnumerable<Employee> employees;
		private IEnumerable<Book> books;
		public ManagerView(Manager manager)
        {
			this.currentManager = manager;
            InitializeComponent();
        }
		private async  void  btn_manager_employee_Click(object sender, RoutedEventArgs e)
		{
			TabControl_manager.SelectedItem = Tab_manager_employee;
			
			employees = await employeeService.GetAll();
			empGrid.ItemsSource = employees;
		}

	

		private async void btn_manager_books_Click(object sender, RoutedEventArgs e)
		{
			

			TabControl_manager.SelectedItem = Tab_manager_books;
			books = await bookService.GetAll();
			bookGrid.ItemsSource = books;

		//	var esss = from book in books where (book.Name == "yerlma") select book;//
		}

		private void btn_manager_cash_Click(object sender, RoutedEventArgs e)
		{
			TabControl_manager.SelectedItem = Tab_manager_cash;
			balanceDisplay.Content = $"Your total money is {this.currentManager.Balance }";
		}

		private void btn_manager_exit_Click(object sender, RoutedEventArgs e)
		{
			Window login = new Login();
			login.Show();
			this.Close();
		}

		private void btn_manager_addemployee_Click(object sender, RoutedEventArgs e)
		{
			btn_manager_addemployee.IsEnabled = false;
			Window addEmployee = new AddEmployee();
			addEmployee.ShowDialog();
			empGrid.Items.Refresh();
			btn_manager_addemployee.IsEnabled = true;

		}

		private void btn_manager_addbook_Click(object sender, RoutedEventArgs e)
		{
			btn_manager_addbook.IsEnabled = false;
			Window addBook = new AddBook();
			addBook.ShowDialog();
			bookGrid.Items.Refresh();
			btn_manager_addbook.IsEnabled = true;
		}

        private async void payBtn_Click(object sender, RoutedEventArgs e)
        {
			payBtn.IsEnabled = false;
			amountErrorLabel.Content += "";

			if (increaseInput.Text.Trim().Length >0) {
				long amount = long.Parse(increaseInput.Text.Trim());
				Window bill = new BilingPage(amount);
				bool? paySuccess = bill.ShowDialog();

				if(paySuccess == true)
                {
					currentManager.Balance += amount;
					await managerService.Update(currentManager.Id, currentManager);
					
                }
                    
			}
            else {
				amountErrorLabel.Content += "You need to enter an amount";
			}

			payBtn.IsEnabled = true;
        }

        private void increaseInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

        private void TabControl_manager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

