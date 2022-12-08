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
    /// Логика взаимодействия для SchedulePerformanceAddEdit.xaml
    /// </summary>
    public partial class SchedulePerformanceAddEdit : Page
    {
        SchedulePerfomance contextSchedule;
        public SchedulePerformanceAddEdit(SchedulePerfomance schedule)
        {
            InitializeComponent();
            CbPerformance.ItemsSource = App.DB.Performance.ToList();
            CbGroup.ItemsSource = App.DB.Group.ToList();
            contextSchedule = schedule;
            DataContext = schedule;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (contextSchedule.Performance == null)
            {
                errorMessage += "Выберите выступление\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextSchedule.Id == 0)
            {
                App.DB.SchedulePerfomance.Add(contextSchedule);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
