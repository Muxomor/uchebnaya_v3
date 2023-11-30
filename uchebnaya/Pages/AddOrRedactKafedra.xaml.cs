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
    /// Логика взаимодействия для AddOrRedactKafedra.xaml 
    /// </summary>
    public partial class AddOrRedactKafedra : Page
    {
        private Kafedra kafedra;
        public AddOrRedactKafedra(Kafedra kafedra)
        {
            InitializeComponent();
            this.kafedra = kafedra;
            this.DataContext = kafedra;
            fac_abrCB.ItemsSource = App.db.Faculty.ToArray();
            if (App.IsPageEnable)
            {
                fac_abrCB.SelectedItem = null;
                kafedraShifrTB.IsEnabled = App.IsPageEnable;
            }
            else
            {
                fac_abrCB.SelectedItem = kafedra.Faculty;
                kafedraShifrTB.IsEnabled = App.IsPageEnable;
            }
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.GoBack();
            App.IsPageEnable = false;
            App.mainWindow.MainWindowFrame.NavigationService.RemoveBackEntry();
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (App.IsPageEnable == false)
            {

                if (CheckFields() == true)
                {
                    kafedra.kafedra_name = kafedraNameTB.Text;
                    kafedra.fac_abr = fac_abrCB.Text;
                    kafedra.kafedra_shifr = kafedraShifrTB.Text;
                    App.db.SaveChanges();
                    MessageBox.Show("Успешно сохранено");
                    App.mainWindow.MainWindowFrame.GoBack();
                    App.mainWindow.MainWindowFrame.NavigationService.RemoveBackEntry();
                }
                else
                {
                    MessageBox.Show("Заполните все поля данными");
                }
            }
            else
            {
                if (CheckFields() == true)
                {
                    if (App.db.Kafedra.Any(x => x.kafedra_shifr == kafedraShifrTB.Text))
                    {
                        MessageBox.Show("Такая кафедра уже существует");
                    }
                    else
                    {


                        kafedra.kafedra_shifr = kafedraShifrTB.Text;
                        kafedra.fac_abr = fac_abrCB.Text;
                        kafedra.kafedra_name = kafedraNameTB.Text;
                        App.db.Kafedra.Add(kafedra);
                        App.db.SaveChanges();
                        App.mainWindow.MainWindowFrame.GoBack();
                        App.mainWindow.MainWindowFrame.NavigationService.RemoveBackEntry();
                        App.IsPageEnable = false;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля данными");
                }
            }

        }


        private bool CheckFields()
        {
            if (kafedraNameTB.Text.Length > 0 && kafedraShifrTB.Text.Length > 0 && fac_abrCB.SelectedValue != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
