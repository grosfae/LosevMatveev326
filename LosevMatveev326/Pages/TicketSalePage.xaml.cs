using LosevMatveev326.Components.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для TicketSalePage.xaml
    /// </summary>
    public partial class TicketSalePage : Page
    {
        public TicketSalePage()
        {
            InitializeComponent();
            LvTickets.ItemsSource = App.DB.TicketSale.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TicketSaleAddEdit(new TicketSale()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedTicket = LvTickets.SelectedItem as TicketSale;
            if (selectedTicket == null)
            {
                MessageBox.Show("Выберите билет");
                return;
            }
            NavigationService.Navigate(new TicketSaleAddEdit(selectedTicket));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedTicket = LvTickets.SelectedItem as TicketSale;
            if (selectedTicket == null)
            {
                MessageBox.Show("Выберите билет");
                return;
            }
            App.DB.TicketSale.Remove(selectedTicket);
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
                LvTickets.ItemsSource = App.DB.TicketSale.ToList();
            }
            else
            {
                LvTickets.ItemsSource = App.DB.TicketSale.Where(a => a.Performance.Name.ToString().Contains(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
