using LosevMatveev326.Components.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для PerformanceAddEdit.xaml
    /// </summary>
    public partial class PerformanceAddEdit : Page
    {
        Performance contextPerformance;
        public PerformanceAddEdit(Performance performance)
        {
            InitializeComponent();
            contextPerformance = performance;
            DataContext = performance;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextPerformance.Name))
            {
                errorMessage += "Введите название выступления\n";
            }
            if (contextPerformance.Date == null)
            {
                errorMessage += "Выберите дату\n";
            }
            if (contextPerformance.Time == null)
            {
                errorMessage += "Выберите время\n";
            }
            if (contextPerformance.TicketPrice == 0)
            {
                errorMessage += "Введите цену билета\n";
            }
            if (contextPerformance.TicketAmount == 0)
            {
                errorMessage += "Введите количество билетов\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextPerformance.Id == 0)
            {
                App.DB.Performance.Add(contextPerformance);
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
