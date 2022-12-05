using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrainerApp.Components.Model;

namespace TrainerApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LosevMatveev326Entities DB = new LosevMatveev326Entities();
        public static Employee LoggedEmployee;
    }
}
