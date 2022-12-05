using HRManager_App.Components.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HRManager_App
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
