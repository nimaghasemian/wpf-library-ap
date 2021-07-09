using Microsoft.Win32;
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
	/// Interaction logic for Sign_in_edit_info.xaml
	/// </summary>
	public partial class Sign_in_edit_info : Window
	{
		public Sign_in_edit_info(string tilte="Sign in")
		{
			InitializeComponent();
			lbl_siginin_title.Content = tilte;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Billing_Page billing_Page = new Billing_Page();
			billing_Page.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			OpenFileDialog op = new OpenFileDialog();  
			op.Title = "Select a picture";  
			op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +  
			"JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +  
			"Portable Network Graphic (*.png)|*.png";  
			if (op.ShowDialog() == true)  
			{  
				imgPhoto.Source = new BitmapImage(new Uri(op.FileName));  
			}  
		}
	}
}
