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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            errorLabel.Content = "";
            ctnButton.IsEnabled = false;
            //Validating User

            Employee newEmployee = new Employee()
            {
                Name = nameInput.Text.Trim(),
                Email = emailInput.Text.Trim(),
                PhoneNumber = phoneInput.Text.Trim(),
                Password = passwordInput.Password,
                Salary = 10000

            };

            EmployeeValidator employeeValidator = new EmployeeValidator();
            var validationResult = await employeeValidator.ValidateAsync(newEmployee);

            if (validationResult.IsValid)
            {

                UserDataService<Employee> emplyeeService = new UserDataService<Employee>(new WpfLibraryDbContextFactory());
                await emplyeeService.Create(newEmployee);
                MessageBox.Show("Employee Created Successfully");
                this.Close();
            }


            else
            {
                foreach (var error in validationResult.Errors)
                {
                    errorLabel.Content += error.ErrorMessage + "\n";
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
