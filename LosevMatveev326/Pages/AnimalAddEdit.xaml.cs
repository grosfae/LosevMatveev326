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
    /// Логика взаимодействия для AnimalAddEdit.xaml
    /// </summary>
    public partial class AnimalAddEdit : Page
    {
        Animal contextAnimal;
        public AnimalAddEdit(Animal animal)
        {
            InitializeComponent();
            CbTypes.ItemsSource = App.DB.TypeAnimal.ToList();
            CbCages.ItemsSource = App.DB.Cage.ToList();
            CbGroup.ItemsSource = App.DB.Group.ToList();
            contextAnimal = animal;
            DataContext = animal;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextAnimal.Name))
            {
                errorMessage += "Введите имя\n";
            }
            if (contextAnimal.Age == 0 || contextAnimal.Age <0)
            {
                errorMessage += "Введите корректный возраст\n";
            }
            if (contextAnimal.TypeAnimal == null)
            {
                errorMessage += "Выберите вид\n";
            }
            if (contextAnimal.Cage == null)
            {
                errorMessage += "Выберите клетку\n";
            }
            if(string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextAnimal.Id == 0)
            {
                App.DB.Animal.Add(contextAnimal);
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
