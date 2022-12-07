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
    /// Логика взаимодействия для PerformancePage.xaml
    /// </summary>
    public partial class PerformancePage : Page
    {
        public PerformancePage()
        {
            InitializeComponent();
            LvPerformance.ItemsSource = App.DB.Performance.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PerformanceAddEdit(new Performance() { Date = DateTime.Now.Date }));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedPerformance = LvPerformance.SelectedItem as Performance;
            if (selectedPerformance == null)
            {
                MessageBox.Show("Выберите выступление");
                return;
            }
            NavigationService.Navigate(new PerformanceAddEdit(selectedPerformance));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPerformance = LvPerformance.SelectedItem as Performance;
            if (selectedPerformance == null)
            {
                MessageBox.Show("Выберите выступление");
                return;
            }
            App.DB.Performance.Remove(selectedPerformance);
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
                LvPerformance.ItemsSource = App.DB.Performance.ToList();
            }
            else
            {
                LvPerformance.ItemsSource = App.DB.Performance.Where(a => a.Name.ToString().Contains(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
