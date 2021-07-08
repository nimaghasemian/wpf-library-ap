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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		private void btn_signin_Click(object sender, RoutedEventArgs e)
		{
            Sign_in_edit_info signpage = new Sign_in_edit_info();
            signpage.Show();
            this.Close();
		}

		private void btn_welcom_exit_Click(object sender, RoutedEventArgs e)
		{
            this.Close();
		}
	}
}
