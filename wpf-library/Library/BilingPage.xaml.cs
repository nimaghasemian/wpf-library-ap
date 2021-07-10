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

namespace Library
{
    /// <summary>
    /// Interaction logic for BilingPage.xaml
    /// </summary>
    public partial class BilingPage : Window
    {
        private long amount;
        public BilingPage(long amount)
        {
            this.amount = amount;
            InitializeComponent();
            amountTextBox.Text = amount.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window signup = new SignUp();
            signup.Show();
            this.Close();
            
        }
    }
}
