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
    /// Логика взаимодействия для SchedulePerformancePage.xaml
    /// </summary>
    public partial class SchedulePerformancePage : Page
    {
        public SchedulePerformancePage()
        {
            InitializeComponent();
            if (App.LoggedEmployee.PostId != (int)CircusPosts.Clown && App.LoggedEmployee.PostId != (int)CircusPosts.Trainer)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                LvSchedulePerfomance.ItemsSource = App.DB.SchedulePerfomance.ToList();
            }
            else
            {
                LvSchedulePerfomance.ItemsSource = App.DB.SchedulePerfomance.Where(x => x.GroupId == App.LoggedEmployee.GroupId).ToList();
            }

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SchedulePerformanceAddEdit(new SchedulePerfomance()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchedule = LvSchedulePerfomance.SelectedItem as SchedulePerfomance;
            if (selectedSchedule == null)
            {
                MessageBox.Show("Выберите выступление");
                return;
            }
            NavigationService.Navigate(new SchedulePerformanceAddEdit(selectedSchedule));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchedule = LvSchedulePerfomance.SelectedItem as SchedulePerfomance;
            if (selectedSchedule == null)
            {
                MessageBox.Show("Выберите выступление");
                return;
            }
            App.DB.SchedulePerfomance.Remove(selectedSchedule);
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
                LvSchedulePerfomance.ItemsSource = App.DB.SchedulePerfomance.ToList();
            }
            else
            {
                LvSchedulePerfomance.ItemsSource = App.DB.SchedulePerfomance.Where(a => a.Performance.Name.ToString().Contains(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
