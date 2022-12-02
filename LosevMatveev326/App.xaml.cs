using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LosevMatveev326.Components;
using LosevMatveev326.Components.Model;

namespace LosevMatveev326
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LosevMatveev326Entities DB = new LosevMatveev326Entities();
        public static Employee LoggedEmployee;
        Animal animal;
    }
}
