using Library.Validators.CreditCardValidators;
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
    /// Interaction logic for BilingPage.xaml
    /// </summary>
    public partial class BilingPage : Window
    {
        private readonly long amount;

        public BilingPage(long amount)
        {
            //this.user = user;
            this.amount = amount;

            InitializeComponent();
            amountTextBox.Text = amount.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            errorLabel.Content = "";

            CardNumberValidator numberValidator = new CardNumberValidator();
            var numberValidationResult = numberValidator.Validate(cardNumberInput.Text);

            CVVvalidator cvvValidator = new CVVvalidator();
            var cvvValidationResult = cvvValidator.Validate(cvvInput.Text);




            

            if (numberValidationResult.IsValid)
            {
                if (cvvValidationResult.IsValid)
                {
                    if (yearInput.Text != "" && monthInput.Text != "")
                    {
                        int year = Int32.Parse(yearInput.Text) + 2000;
                        int month = Int32.Parse(monthInput.Text);
                        DateTime expDate = new DateTime(year, month, 1);
                        expDateValidator date = new expDateValidator();
                        var expDateValidationResult = date.Validate(expDate);
                        if (expDateValidationResult.IsValid)
                        {
                            this.DialogResult = true;
                            this.Close();
                        }
                        else
                        {
                            foreach (var error in expDateValidationResult.Errors)
                            {
                                errorLabel.Content += error.ErrorMessage + "\n";
                            }
                        }
                    }
                    else
                    {
                        errorLabel.Content += "year and month is required\n";
                    }
                }
                else
                {
                    foreach (var error in cvvValidationResult.Errors)
                    {
                        errorLabel.Content += error.ErrorMessage + "\n";
                    }
                }
            }
            else
            {
                foreach (var error in numberValidationResult.Errors)
                {
                    errorLabel.Content += error.ErrorMessage + "\n";
                }
            }

        }




        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
    }

}

