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
using uchebnaya.Pages;

namespace uchebnaya.Components
{
    /// <summary>
    /// Логика взаимодействия для KafedraUserControl.xaml
    /// </summary>
    public partial class KafedraUserControl : UserControl
    {
        Kafedra kafedra;
        public KafedraUserControl(Kafedra _kafedra)
        {
            kafedra = _kafedra;
            InitializeComponent();
            facultetAbrTB.Text=kafedra.fac_abr.ToString();  
            kafedraNameTB.Text=kafedra.kafedra_name.ToString();
            kafedraShifrTB.Text=kafedra.kafedra_shifr.ToString();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new AddOrRedactKafedra(kafedra));
        }
    }
}
