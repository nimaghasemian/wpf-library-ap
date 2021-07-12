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

namespace Library
{
    /// <summary>
    /// Interaction logic for CheckPasswordDialoag.xaml
    /// </summary>
    /// 

    public partial class CheckPasswordDialog : Window
    {
        private BasePerson currentMember;
        public CheckPasswordDialog(BasePerson currentUser)
        {
            InitializeComponent();
            cnfrmBtn.IsEnabled = false;
            currentMember = currentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cancelBtn.IsEnabled = false;
            this.DialogResult = false;
            this.Close();
            cancelBtn.IsEnabled = true;
        }

        private void passwordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordInput.Password.Length == 0)
                cnfrmBtn.IsEnabled = false;
            else
                cnfrmBtn.IsEnabled = true;

        }

        private void ConfirmPassword(object sender, RoutedEventArgs e)
        {
            errorLabel.Content += "";
            if (passwordInput.Password == currentMember.Password)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                errorLabel.Content += "That password is wrong";
            }

        }
    }
}
