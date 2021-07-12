using Library.Validators;
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

		/*
		 * Bussiness logic
		 * */
		private async Task showAllBooks()
		{
			books = await bookService.GetAll();
			bookGrid.ItemsSource = from book in books
								   select new
								   {
									   BookName = book.Name,
									   Author = book.Author,
									   Genre = book.Genre,
									   ISBN = book.ISBN
								   };
		}
		private async Task showAvailableBooks()
		{
			books = await bookService.GetAll();
			bookGrid.ItemsSource = from book in books
								   where book.Remaining > 0
								   select new
								   {
									   BookName = book.Name,
									   Author = book.Author,
									   Genre = book.Genre,
									   ISBN = book.ISBN
								   };
		}

		private async Task showBorrowedBooks()
		{
			var allBookTransactions = await bookTransactionService.GetAll();
			var currentlyBorrowedBooks = from transaction in allBookTransactions
										 where transaction.RetrunStatus == false
										 select transaction.RentedBook;
			bookGrid.ItemsSource = currentlyBorrowedBooks;

		}


		private async Task showAllMembers()
		{
			members = await memberService.GetAll();
			usersGrid.ItemsSource = members;
		}

		private async Task showLatePeople()
		{
			var allBookTransactions = await bookTransactionService.GetAll();
			var latePeople = from transaction in allBookTransactions
							 where (DateTime.Now.Day - transaction.ReturnDate.Day) < 0
							 select transaction.RentingMember;

			usersGrid.ItemsSource = from latePerson in latePeople
									select new
									{
										Name = latePerson.Name,
										Email = latePerson.Name
									};
		}

		private async Task showUnsubedMembers()
		{
			members = await memberService.GetAll();
			var unsubedMembers = from member in members
								 where (DateTime.Now.Day - member.LastPayDate.Day) > 30
								 select new
								 {
									 Name = member.Name,
									 Email = member.Email,
									 LastSubDate = member.LastPayDate
								 };
			usersGrid.ItemsSource = unsubedMembers;

		}
		/*
		 * Event handlers
		 */

		private async void btn_employee_books_Click(object sender, RoutedEventArgs e)

		{
			TabControl_employee.SelectedItem = Tab_employee_books;
			await showBorrowedBooks();

		}


		private async void btn_employee_users_Click(object sender, RoutedEventArgs e)
		{
			TabControl_employee.SelectedItem = Tab_employee_users;
			await showAllMembers();
		}

		private void btn_employee_cart_Click(object sender, RoutedEventArgs e)
		{
			TabControl_employee.SelectedItem = Tab_employee_cart;
			nameInput.Text = activeEmployee.Name;
			emailInput.Text = activeEmployee.Email;
			phoneInput.Text = activeEmployee.PhoneNumber;
			balanceEdt.Text = activeEmployee.Balance.ToString();

			errorLabel.Content = "";

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
			if (usersGrid.SelectedItem != null)
			{
				var selection = usersGrid.SelectedItem;
				Member selectedMember = new Member();
				selectedMember = (Member)selection;
				userSearchInput.Text = selectedMember.Email;
			}
		}


		private async void Button_Click_1(object sender, RoutedEventArgs e)
		{
			await showAllMembers();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			var lateForSubscribtion = from member in members where (DateTime.Now.Day - member.LastPayDate.Day) > 30 select new { Name = member.Name, Email = member.Email, Phone = member.PhoneNumber, RemainingDays = (DateTime.Now.Day - member.LastPayDate.Day) };
			usersGrid.ItemsSource = lateForSubscribtion;
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			if (userSearchInput.Text.Trim() == "")
			{
				MessageBox.Show("You should enter a name first");
			}
			else
			{
				var foundUsers = from member in members
								 where (member.Name == userSearchInput.Text.Trim())
								 select member;

				Member foundUser = foundUsers.First();
			}
		}





		private async void showBorrowedBooks_btn(object sender, RoutedEventArgs e)
		{
			await showBorrowedBooks();
		}



		private async void showAllBtn_Click(object sender, RoutedEventArgs e)
		{
			await showAllBooks();
		}

		private async void showAvailableBtn_Click(object sender, RoutedEventArgs e)
		{
			await showAvailableBooks();
		}

		private async void lateBtn_Click(object sender, RoutedEventArgs e)
		{
			await showLatePeople();
		}

		private async void searchBtn_Click(object sender, RoutedEventArgs e)
		{
			searchBtn.IsEnabled = false;

			string email = userSearchInput.Text.Trim();

			Member foundMember = await memberService.GetByEmail(email);

			if (foundMember != null)
			{
				Window editPersonPage = new UserInfoPage(foundMember, activeEmployee);
				editPersonPage.ShowDialog();
			}
			else
			{
				MessageBox.Show("user not found");
			}

			searchBtn.IsEnabled = true;
		}

		private void userSearchInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (userSearchInput.Text.Length < 0)
				searchBtn.IsEnabled = false;
		}

		private async void unsubBtn_Click(object sender, RoutedEventArgs e)
		{
			await showUnsubedMembers();
		}

		private async void updateInfoBtn_Click(object sender, RoutedEventArgs e)
		{


			updateInfoBtn.IsEnabled = false;
			Employee updatedEmployee = new Employee()
			{
				Name = nameInput.Text.Trim(),
				Email = activeEmployee.Email,
				PhoneNumber = phoneInput.Text.Trim(),

				Balance = activeEmployee.Balance,
				isLoggedIn = activeEmployee.isLoggedIn,
				Password = activeEmployee.Password
			};

			NameValidator validator = new NameValidator();
			var nameValidationResult = validator.Validate(updatedEmployee.Name);

			PhoneNumberValidator phoneValidator = new PhoneNumberValidator();
			var phoneValidationResult = phoneValidator.Validate(updatedEmployee.PhoneNumber);

			

			if (nameValidationResult.IsValid && phoneValidationResult.IsValid)
			{
				Window confirmPassDialog = new CheckPasswordDialog(activeEmployee);
				bool? passwordConfirm = confirmPassDialog.ShowDialog();

				if (passwordConfirm == true)
				{
					await employeeService.Update(activeEmployee.Id, activeEmployee);
				}
				else
				{
					errorLabel.Content += "You need to confirm your password to update info";
				}

			}
			else
			{
				foreach (var error in nameValidationResult.Errors)
				{
					errorLabel.Content += error.ErrorMessage + "\n";
				}
				foreach (var error in phoneValidationResult.Errors)
				{
					errorLabel.Content += error.ErrorMessage + "\n";
				}
			}
			updateInfoBtn.IsEnabled = false;
		}
	}
}
