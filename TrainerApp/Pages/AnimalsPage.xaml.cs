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
using TrainerApp.Components.Model;

namespace TrainerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        public AnimalsPage()
        {
            InitializeComponent();
            LvAnimals.ItemsSource = App.DB.Animal.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalAddEdit(new Animal()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnimal = LvAnimals.SelectedItem as Animal;
            NavigationService.Navigate(new AnimalAddEdit(selectedAnimal));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnimal = LvAnimals.SelectedItem as Animal;
            if (selectedAnimal == null)
            {
                MessageBox.Show("Выберите животное");
                return;
            }
            App.DB.Animal.Remove(selectedAnimal);
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
                LvAnimals.ItemsSource = App.DB.Animal.ToList();
            }
            else
            {
                LvAnimals.ItemsSource = App.DB.Animal.Where(a => a.Name.ToLower().Contains(TbSearch.Text.ToLower())
                || a.TypeAnimal.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
