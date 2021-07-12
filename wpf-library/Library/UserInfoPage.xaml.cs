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
using Wpf_library.EntityFramework;
using Wpf_library.EntityFramework.Services;
using System.Linq;
using Library.Validators;

namespace Library
{
    /// <summary>
    /// Interaction logic for UserInfoPage.xaml
    /// </summary>
    public partial class UserInfoPage : Window
    {
        private readonly BookDataService bookService = new BookDataService(new WpfLibraryDbContextFactory());
        private readonly UserDataService<Member> memberService = new UserDataService<Member>(new WpfLibraryDbContextFactory());
        private readonly BookTransactionDataSerivce bookTransactionService = new BookTransactionDataSerivce(new WpfLibraryDbContextFactory());
        private IEnumerable<Book> borrowedBooks;
        private IEnumerable<Member> members;
        private Member currentMember;
        private BasePerson currentCaller;
        public UserInfoPage(Member member,BasePerson caller)
        {
            InitializeComponent();
            this.currentMember = member;
            this.currentCaller = caller;
            nameInput.Text = member.Name;
            emailInput.Text = member.Email;
            phoneInput.Text = member.PhoneNumber;
            joinDateInput.Text = member.MemberShipDate.ToLongDateString();
            remainingDaysInput.Text = ((DateTime.Now - member.LastPayDate).Days + 30).ToString();
            if(caller == member) {
                deleteBtn.Visibility = Visibility.Collapsed;
            }else  {
                updateInfoBtn.Visibility = Visibility.Collapsed;
                nameInput.IsEnabled = false;
                emailInput.IsEnabled = false;
                phoneInput.IsEnabled = false;
            }
        }

        private async void showBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<BookTransaction> allBorrowedBooks = await  bookTransactionService.GetByMemberID(this.currentMember.Id);
            var bookInfo = from bookTransaction in allBorrowedBooks
                           where (bookTransaction.RetrunStatus == false)
                           select new { BookName = bookTransaction.RentedBook.Name, ReturnDate = bookTransaction.ReturnDate.ToLongDateString() };

            bookGrid.ItemsSource = bookInfo;
        }

        private async void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<BookTransaction> allBorrowedBooks = await bookTransactionService.GetByMemberID(this.currentMember.Id);
            var bookTransactions = from bookTransaction in allBorrowedBooks
                           where (bookTransaction.RetrunStatus == false)
                           select bookTransaction;
            foreach(BookTransaction transaction in bookTransactions)
            {
                transaction.RetrunStatus = true;
                Book returnedBook = transaction.RentedBook;
                returnedBook.Remaining += 1;
                await bookService.Update(returnedBook.Id, returnedBook);
                await bookTransactionService.Update(transaction.Id, transaction);
                await memberService.Delete(this.currentMember.Id);
            }
        }

        private async void updateInfoBtn_Click(object sender, RoutedEventArgs e)
        {

            errorLabel.Content = "";

            updateInfoBtn.IsEnabled = false;
            Member updatedMember = new Member()
            {
                Name = nameInput.Text.Trim(),
                Email = emailInput.Text.Trim(),
                PhoneNumber = phoneInput.Text.Trim(),
                MemberShipDate = currentMember.MemberShipDate,
                LastPayDate = currentMember.LastPayDate,
                Balance = currentMember.Balance,
                isLoggedIn = currentMember.isLoggedIn,
                Password = currentMember.Password
            };

            NameValidator validator = new NameValidator();
            var nameValidationResult = validator.Validate(currentMember.Name);

            PhoneNumberValidator phoneValidator = new PhoneNumberValidator();
            var phoneValidationResult = phoneValidator.Validate(currentMember.PhoneNumber);

            if (phoneValidationResult.IsValid && nameValidationResult.IsValid)
            {
                Window confirmPassDialog = new CheckPasswordDialog(currentMember);
                bool? passwordConfirm = confirmPassDialog.ShowDialog();

                if (passwordConfirm == true)
                {
                    await memberService.Update(currentMember.Id, updatedMember);
                }
                else
                {
                    errorLabel.Content += "You need to confirm your password to update info";
                }

            }
            else {
                foreach (var error in nameValidationResult.Errors)
                {
                    errorLabel.Content += error.ErrorMessage + "\n";
                }
                foreach (var error in phoneValidationResult.Errors)
                {
                    errorLabel.Content += error.ErrorMessage + "\n";
                }
            }

        }
    }
}
