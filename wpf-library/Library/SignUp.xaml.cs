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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window login = new Login();
            
            login.Show();
            this.Close();
        }

        private  async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            errorLabel.Content = "";
            ctnButton.IsEnabled = false;
            //Validating User
            if (passwordInput.Password == "" || passwordInput.Password == confirmPasswordInput.Password)
            {
                Member newMember = new Member()
                {
                    Name = nameInput.Text.Trim(),
                    Email = emailInput.Text.Trim(),
                    PhoneNumber = phoneInput.Text.Trim(),
                    Password = passwordInput.Password,
                    MemberShipDate = DateTime.Now

                };

                MemberValidator signUpValidator = new MemberValidator();
                var validationResult = await signUpValidator.ValidateAsync(newMember);

                if (validationResult.IsValid) {
                    Window bill = new BilingPage(2000);
                    
                    bool? paySuccess = bill.ShowDialog();
                    
                    if(paySuccess == true)
                    {
                        newMember.Balance += 2000;
                        newMember.LastPayDate = DateTime.Now;
                        newMember.MemberShipDate = DateTime.Now;
                        UserDataService<Member> userService = new UserDataService<Member>(new WpfLibraryDbContextFactory());
                        await userService.Create(newMember);
                        MessageBox.Show("You Signed Up Successfully. Please Login Now");
                        Window login = new Login();
                        login.Show();
                        this.Close();
                    }
                    
                }
                else
                {
                    foreach(var error in validationResult.Errors)
                    {
                        errorLabel.Content += error.ErrorMessage + "\n";
                    }
                }


            }
            else
            {
                errorLabel.Content = "passwords do not match";
            }
            ctnButton.IsEnabled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
