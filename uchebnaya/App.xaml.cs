using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using uchebnaya.Components;

namespace uchebnaya
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static shamaev322_uchebnayaEntities db = new shamaev322_uchebnayaEntities();
        public static MainWindow mainWindow;
        public static bool IsPageEnable = false;
    }
}
