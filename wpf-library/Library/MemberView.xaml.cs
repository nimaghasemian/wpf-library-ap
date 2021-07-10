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
    /// Interaction logic for MemberView.xaml
    /// </summary>
    public partial class MemberView : Window
    {
        public MemberView(Wpf_library.Domain.Models.Member member)
        {
            InitializeComponent();
        }

		private void btn_user_allbooks_Click(object sender, RoutedEventArgs e)
		{
			TabControl_user.SelectedItem = Tab_user_allBooks;
		}

		private void btn_user_mybooks_Click(object sender, RoutedEventArgs e)
		{
			TabControl_user.SelectedItem = Tab_user_myBooks;
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
	}
}

