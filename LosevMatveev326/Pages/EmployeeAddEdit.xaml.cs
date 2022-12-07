using LosevMatveev326.Components.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace LosevMatveev326.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddEdit.xaml
    /// </summary>
    public partial class EmployeeAddEdit : Page
    {
        Employee contextEmployee;
        public EmployeeAddEdit(Employee employee)
        {
            InitializeComponent();
            CbPost.ItemsSource = App.DB.Post.ToList();
            CbGroup.ItemsSource = App.DB.Group.ToList();
            contextEmployee = employee;
            DataContext = contextEmployee;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextEmployee.FirstName))
            {
                errorMessage += "Введите ммя\n";
            }
            if (string.IsNullOrWhiteSpace(contextEmployee.LastName))
            {
                errorMessage += "Введите фамилию\n";
            }
            if (string.IsNullOrWhiteSpace(contextEmployee.Patronymic))
            {
                errorMessage += "Введите отчество\n";
            }
            if (string.IsNullOrWhiteSpace(contextEmployee.Phone))
            {
                errorMessage += "Введите телефон\n";
            }
            if (string.IsNullOrWhiteSpace(contextEmployee.Address))
            {
                errorMessage += "Введите адрес\n";
            }
            if (contextEmployee.Post == null)
            {
                errorMessage += "Выберите должность\n";
            }
            if (contextEmployee.Post.Id == 4)
            {
                errorMessage += "Выберите правильную должность\n";
            }
            if (contextEmployee.Birthday == null)
            {
                errorMessage += "Выберите дату\n";
            }
            if (contextEmployee.Salary == 0)
            {
                errorMessage += "Введите зарплату\n";
            }
            if (string.IsNullOrWhiteSpace(contextEmployee.Address))
            {
                errorMessage += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextEmployee.Id == 0)
            {
                App.DB.Employee.Add(contextEmployee);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnEditImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if(dialog.ShowDialog().GetValueOrDefault())
            {
                contextEmployee.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextEmployee;
            }
        }
        private void FullName_PreviewTextImput(object sender, TextCompositionEventArgs e)
        {
            if(Regex.IsMatch(e.Text, @"[A-zА-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void Digits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
