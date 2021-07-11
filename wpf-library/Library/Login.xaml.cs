using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (userTypeInput.SelectedIndex == 3)
                joinButton.Visibility = Visibility.Visible;
            else if (userTypeInput.SelectedIndex != 0)
            {
                
                    joinButton.Visibility = Visibility.Hidden;
            }
        }

        private   async void  Button_Click(object sender, RoutedEventArgs e)
        {
            passwordErrorLabel.Content = "";
            emailErrorLabel.Content = "";
            if (userTypeInput.SelectedIndex == 1) 
            {
                UserDataService<Manager> managerService = new UserDataService<Manager>(new WpfLibraryDbContextFactory());
                Manager manager = await managerService.GetByEmail(emailInput.Text.Trim().ToLower());
                if (manager != null)
                {
                    if(manager.Password == passwordInput.Password) 
                    {
                        Window managerWindow = new ManagerView(manager);
                        managerWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        passwordErrorLabel.Content = "That password is incorrect";
                    }

                }else
                {
                    emailErrorLabel.Content = "That email is not registered";
                } 

            }  else if (userTypeInput.SelectedIndex == 2)
            {
                UserDataService<Employee> employeeService = new UserDataService<Employee>(new WpfLibraryDbContextFactory());
                Employee employee = await employeeService.GetByEmail(emailInput.Text.Trim().ToLower());
                if (employee != null)
                {
                    if (employee.Password == passwordInput.Password)
                    {
                        Window employeeWindow = new EmployeeView(employee);
                        employeeWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        passwordErrorLabel.Content = "That password is incorrect";
                    }

                }
                else
                {
                    emailErrorLabel.Content = "That email is not registered";
                }

            }
            else if (userTypeInput.SelectedIndex == 3)
            {
                UserDataService<Member> memberService = new UserDataService<Member>(new WpfLibraryDbContextFactory());
                Member member = await memberService.GetByEmail(emailInput.Text.Trim().ToLower());
                if (member != null)
                {
                    if (member.Password == passwordInput.Password)
                    {
                        Window memberWindow = new MemberView(member);
                        memberWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        passwordErrorLabel.Content = "That password is incorrect";
                    }

                }
                else
                {
                    emailErrorLabel.Content = "That email is not registered";
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Window signUpWindow = new SignUp();
            this.Close();
            signUpWindow.Show();
            
        }
    }
}
