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

namespace wpf_library
{
	/// <summary>
	/// Interaction logic for User.xaml
	/// </summary>
	public partial class User : Window
	{
		public User()
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
			Sign_in_edit_info sign_In_Edit_Info = new Sign_in_edit_info();
			sign_In_Edit_Info.Show();
		}

		private void btn_user_exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
