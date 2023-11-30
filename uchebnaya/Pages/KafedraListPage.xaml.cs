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
using uchebnaya.Components;

namespace uchebnaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для KafedraListPage.xaml
    /// </summary>
    public partial class KafedraListPage : Page
    {
        public Kafedra kafedra_;
        public KafedraListPage()
        {
            var kafedra = App.db.Kafedra.ToList();
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Kafedra> kafedras = App.db.Kafedra;
            if(SortCb.SelectedIndex!=0)
            {
                if (SortCb.SelectedIndex==1)
                {
                    kafedras = kafedras.OrderBy(x => x.kafedra_name);
                }
                else if (SortCb.SelectedIndex==2)
                {
                    kafedras = kafedras.OrderByDescending(x => x.kafedra_name);
                }
            }
            if(NameSearchTB.Text!="")
            {
                kafedras = kafedras.Where(x => x.kafedra_name.ToLower().Contains(NameSearchTB.Text.ToLower()));
            }
            kafedraWP.Children.Clear();
            foreach(var item in kafedras)
            {
                kafedraWP.Children.Add(new KafedraUserControl(item));
            }

        }
        private void AddKafedraBtn_Click(object sender, RoutedEventArgs e)
        {
            App.IsPageEnable = true;
            var kafedra = App.db.Kafedra.ToList();
            kafedra_ = new Kafedra();
            App.mainWindow.MainWindowFrame.Navigate(new AddOrRedactKafedra(kafedra_));
        }

        private void NameSearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
