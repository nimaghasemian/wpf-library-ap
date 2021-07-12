using Library.Validators;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            errorLabel.Content = "";
            ctnButton.IsEnabled = false;
            //Validating Book
            if (ISBNInput.Text.Trim() == "") {
                errorLabel.Content += "ISBN is required";
            }
            else
            {
                Book newBook = new Book()
                {
                    Name = nameInput.Text.Trim(),
                    Author = authorInput.Text.Trim(),
                    ISBN = Int32.Parse(ISBNInput.Text.Trim()),
                    Genre = genreInput.Text.Trim(),
                    Remaining = 1

                };

                BookValidator bookValidator = new BookValidator();
                var validationResult =  bookValidator.Validate(newBook);

                if (validationResult.IsValid)
                {

                    BookDataService bookService = new BookDataService(new WpfLibraryDbContextFactory());
                    await bookService.Create(newBook);
                    MessageBox.Show("Book Added Successfully");
                    this.Close();
                }


                else
                {
                    foreach (var error in validationResult.Errors)
                    {
                        errorLabel.Content += error.ErrorMessage + "\n";
                    }
                }

            }

            ctnButton.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
