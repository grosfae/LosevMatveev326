﻿using LosevMatveev326.Components.Model;
using System;
using System.Collections.Generic;
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
            contextEmployee = employee;
            DataContext = contextEmployee;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
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