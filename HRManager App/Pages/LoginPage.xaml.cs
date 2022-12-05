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

namespace HRManager_App.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Phone != null)
                TbPhone.Text = Properties.Settings.Default.Phone;
            if (Properties.Settings.Default.Password != null)
                PbPassword.Password = Properties.Settings.Default.Password;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var employee = App.DB.Employee.FirstOrDefault(x => x.Phone == TbPhone.Text);
            if (employee == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (employee.Password != PbPassword.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            if (employee.PostId != 5)
            {
                MessageBox.Show("Вы пытаетесь войти не под своей учетной записью");
                return;
            }
            if (SaveCb.IsChecked == true)
            {
                Properties.Settings.Default.Phone = TbPhone.Text;
                Properties.Settings.Default.Password = PbPassword.Password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Phone = null;
                Properties.Settings.Default.Password = null;
                Properties.Settings.Default.Save();
            }
            App.LoggedEmployee = employee;
            NavigationService.Navigate(new MainPage());
        }
    }
}
