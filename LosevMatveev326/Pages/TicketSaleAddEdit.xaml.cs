using LosevMatveev326.Components.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для TicketSaleAddEdit.xaml
    /// </summary>
    public partial class TicketSaleAddEdit : Page
    {
        TicketSale contextTicketSale;
        public TicketSaleAddEdit(TicketSale ticketSale)
        {
            InitializeComponent();
            CbPerformance.ItemsSource = App.DB.Performance.ToList();
            contextTicketSale = ticketSale;
            DataContext = ticketSale;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (contextTicketSale.Performance == null)
            {
                errorMessage += "Выберите выступление\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextTicketSale.Id == 0)
            {
                App.DB.TicketSale.Add(contextTicketSale);
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
