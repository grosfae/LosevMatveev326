using LosevMatveev326.Components.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ItemAddEdit.xaml
    /// </summary>
    public partial class ItemAddEdit : Page
    {
        Item contextItem;
        public ItemAddEdit(Item item)
        {
            InitializeComponent();
            CbType.ItemsSource = App.DB.TypeItem.ToList();
            contextItem = item;
            DataContext = contextItem;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextItem.Name))
            {
                errorMessage += "Введите наименование\n";
            }
            if (contextItem.TypeItem == null)
            {
                errorMessage += "Выберите тип реквизита\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextItem.Id == 0)
            {
                App.DB.Item.Add(contextItem);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnEditImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextItem.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextItem;
            }
        }
        private void FullName_PreviewTextImput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-zА-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void Digits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
