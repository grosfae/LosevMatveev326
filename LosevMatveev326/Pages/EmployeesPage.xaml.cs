using LosevMatveev326.Components.Model;
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

namespace LosevMatveev326.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            if (App.LoggedEmployee.Post.Id == 4)
            {
                LvEmployees.ItemsSource = App.DB.Employee.Where(x => x.PostId != 4).ToList();
            }
            if (App.LoggedEmployee.Post.Id == 5)
            {
                LvEmployees.ItemsSource = App.DB.Employee.Where(x => x.PostId != 4 & x.PostId != 5).ToList();
            }
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeAddEdit(new Employee() {Birthday = DateTime.Now.Date}));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = LvEmployees.SelectedItem as Employee;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            NavigationService.Navigate(new EmployeeAddEdit(selectedEmployee));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = LvEmployees.SelectedItem as Employee;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            App.DB.Employee.Remove(selectedEmployee);
            App.DB.SaveChanges();
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            if (string.IsNullOrWhiteSpace(TbSearch.Text))
            {
                LvEmployees.ItemsSource = App.DB.Employee.ToList();
            }
            else
            {
                LvEmployees.ItemsSource = App.DB.Employee.Where(a => a.LastName.ToString().Contains(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
