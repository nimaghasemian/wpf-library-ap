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
	/// Interaction logic for MemberView.xaml
	/// </summary>
	public partial class MemberView : Window
	{
		private readonly BookDataService bookService = new BookDataService(new WpfLibraryDbContextFactory());
		private readonly BookTransactionDataSerivce bookTransactionService = new BookTransactionDataSerivce(new WpfLibraryDbContextFactory());
		private readonly Member activeMember;

		IEnumerable<Book> books;
		IEnumerable<BookTransaction> memberBookTransactions;
		public MemberView(Member member)
		{
			this.activeMember = member;
			InitializeComponent();

		}

		private async void btn_user_allbooks_Click(object sender, RoutedEventArgs e)
		{
			TabControl_user.SelectedItem = Tab_user_allBooks;
			await showAvailableBooks();
			var allMemberTransactions = await bookTransactionService.GetByMemberID(activeMember.Id);
			memberBookTransactions = from trasaction in allMemberTransactions
									 where trasaction.RetrunStatus == false
									 select trasaction;
		}

		private void btn_user_mybooks_Click(object sender, RoutedEventArgs e)
		{
			TabControl_user.SelectedItem = Tab_user_myBooks;
			rentedBooksComboBox.ItemsSource = from book in getAllBooks()
											  select new { Name = book.Name };

		}

		private void btn_user_subscribe_Click(object sender, RoutedEventArgs e)
		{
			TabControl_user.SelectedItem = Tab_user_subscrib;
		}

		private void btn_user_cart_Click(object sender, RoutedEventArgs e)
		{
			TabControl_user.SelectedItem = Tab_user_cart;
		}

		private void btn_user_editinfo_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_user_exit_Click(object sender, RoutedEventArgs e)
		{
			Window login = new Login();
			login.Show();
			this.Close();
		}

		/*
 * business logic
 */

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

		private async Task findBooksByName(string name) {
			books = await bookService.GetAll();
			bookGrid.ItemsSource = from book in books
								   where book.Name == name
								   select new
								   {
									   BookName = book.Name,
									   Author = book.Author,
									   Genre = book.Genre,
									   ISBN = book.ISBN
								   };

		}
		private async Task findBooksByGenre(string genre)
		{
			books = await bookService.GetAll();
			bookGrid.ItemsSource = from book in books
								   where book.Genre == genre
								   select new
								   {
									   Name = book.Name,
									   Author = book.Author,
									   Genre = book.Genre,
									   ISBN = book.ISBN
								   };

		}

		private async Task findBooksByAuthor(string author)
		{
			books = await bookService.GetAll();
			bookGrid.ItemsSource = from book in books
								   where book.Author == author
								   select new Book
								   {
									   Name = book.Name,
									   Author = book.Author,
									   Genre = book.Genre,
									   ISBN = book.ISBN,
									   Remaining = book.Remaining
								   };

		}

		private async void bookSearchBtn_Click(object sender, RoutedEventArgs e)
		{
			if (srchComBox.SelectedIndex == 0) { await findBooksByName(bookSrchInput.Text.Trim()); }
			if (srchComBox.SelectedIndex == 1) { await findBooksByAuthor(bookSrchInput.Text.Trim()); }
			if (srchComBox.SelectedIndex == 2) { await findBooksByGenre(bookSrchInput.Text.Trim()); }
		}

		private void bookGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}



		public bool hasLessThan5()
		{
			
			return memberBookTransactions.ToArray().Length < 5;

		}
		public bool moreThanAweek() {
			
			return (DateTime.Now.Day - activeMember.LastPayDate.Day )+30 >= 7;
		}
		public bool noPastDue()
		{

			
			return getPastDueBooks().Count() == 0;
		}
		public IEnumerable<Book> getPastDueBooks()
		{

			var books = from transaction in memberBookTransactions
						where transaction.ReturnDate < DateTime.Now
						select transaction.RentedBook;
			
			return books;
		}

		public IEnumerable<Book> getAllBooks()
		{

			var books = from transaction in memberBookTransactions
						select transaction.RentedBook;

			return books;
		}


		private async void borrowBtn_Click(object sender, RoutedEventArgs e)
		{
			if (isbnTextbox.Text != "")
			{
				if (hasLessThan5() && noPastDue() && moreThanAweek())
				{
					Book rentee = await bookService.GetByISBN(Int32.Parse(isbnTextbox.Text.Trim()));


					BookTransaction borrow = new BookTransaction()
					{
						RentedBook = rentee,
						RentingMember = activeMember,
						RetrunStatus = false,
						StartDate = DateTime.Now,
						ReturnDate = DateTime.Now.AddDays(14)
					};

					await bookTransactionService.Create(borrow);
					MessageBox.Show("Book added to your books");
                }
                else { MessageBox.Show("you don't meet the conditions"); }
			}
			else { MessageBox.Show("no book selected"); } 
		}
        }
    }





