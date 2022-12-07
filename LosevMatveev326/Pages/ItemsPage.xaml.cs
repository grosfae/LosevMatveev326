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
    /// Логика взаимодействия для ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {
        public ItemsPage()
        {
            InitializeComponent();
            LvItems.ItemsSource = App.DB.Item.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ItemAddEdit(new Item()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = LvItems.SelectedItem as Item;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберите реквизит");
                return;
            }
            NavigationService.Navigate(new ItemAddEdit(selectedItem));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = LvItems.SelectedItem as Item;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберите реквизит");
                return;
            }
            App.DB.Item.Remove(selectedItem);
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
                LvItems.ItemsSource = App.DB.Item.ToList();
            }
            else
            {
                LvItems.ItemsSource = App.DB.Item.Where(a => a.Name.ToString().Contains(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
