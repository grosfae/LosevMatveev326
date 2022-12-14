using LosevMatveev326.Components.Model;
using LosevMatveev326.Components.ModelEnums;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.LoggedEmployee.PostId == (int)CircusPosts.HRManager)
            {
                BtnEmployeeManagment.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new EmployeesPage());
            }
            if (App.LoggedEmployee.PostId == (int)CircusPosts.Itemkeeper)
            {
                BtnItemManagment.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new ItemsPage());
            }
            if (App.LoggedEmployee.PostId == (int)CircusPosts.Trainer)
            {
                BtnAmimalManagment.Visibility = Visibility.Visible;
                BtnSchedulePerfomance.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new AnimalsPage());
            }
            if (App.LoggedEmployee.PostId == (int)CircusPosts.Clown)
            {
                BtnSchedulePerfomance.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new SchedulePerformancePage());
            }
            if (App.LoggedEmployee.PostId == (int)CircusPosts.Casshier)
            {
                BtnTicketSale.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new TicketSale());
            }
            if (App.LoggedEmployee.PostId == (int)CircusPosts.Director)
            {
                BtnAmimalManagment.Visibility = Visibility.Visible;
                BtnEmployeeManagment.Visibility = Visibility.Visible;
                BtnItemManagment.Visibility = Visibility.Visible;
                BtnPerformanceManagment.Visibility = Visibility.Visible;
                BtnSchedulePerfomance.Visibility = Visibility.Visible;
                BtnTicketSale.Visibility = Visibility.Visible;
            }
        }

        private void BtnAmimalManagment_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new AnimalsPage());
        }

        private void BtnEmployeeManagment_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new EmployeesPage());
        }

        private void BtnSolitaire_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new SolitairePage());
        }

        private void BtnItemManagment_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new ItemsPage());
        }

        private void BtnPerformanceManagment_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new PerformancePage());
        }

        private void BtnTicketSale_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new TicketSalePage());
        }

        private void BtnSchedulePerfomance_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new SchedulePerformancePage());
        }

        private void BtnBlackJ_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new BlackJPage());
        }
    }
}
