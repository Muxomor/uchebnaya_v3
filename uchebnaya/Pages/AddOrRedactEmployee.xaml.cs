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
    /// Логика взаимодействия для AddOrRedactEmployee.xaml
    /// </summary>
    public partial class AddOrRedactEmployee : Page
    {
        private employee emp;
        private zav_kafedri zav;
        private engineer eng;
        public AddOrRedactEmployee(employee emp)
        {
            InitializeComponent();
            this.emp = emp;
            DataContext = emp;
            empPositionCB.ItemsSource = App.db.employee.ToArray().Select(x => x.emp_position).Distinct();
            kadedraShifrCB.ItemsSource = App.db.Kafedra.ToArray();
            shefIdCB.ItemsSource=App.db.zav_kafedri.ToArray();
            if(App.IsPageEnable==true)
            {
                shefIdCB.IsEnabled = true;
                SecNameSP.Visibility=Visibility.Visible;
                PatronumicSP.Visibility=Visibility.Visible;
            }
            else
            {
                empPositionCB.SelectedItem = emp.emp_position;
                kadedraShifrCB.SelectedItem = emp.Kafedra;
                shefIdCB.SelectedItem = App.db.zav_kafedri.First(x => x.zav_id == emp.shef_id);

            }
        }

        private bool CheckFields()
        {
            if(App.IsPageEnable==true)
                if(empNameTB.Text.Length>0 && empPatronumicTB.Text.Length>0&&empSalaryTB.Text.Length>0&&empSecondNameTB.Text.Length>0&&empPositionCB.SelectedItem!=null&&kadedraShifrCB.SelectedItem!=null)
                    return true;
            else
                {
                    MessageBox.Show("Заполните все поля");
                    return false;
                }
            else
            {
                if(empNameTB.Text.Length>0 && empSalaryTB.Text.Length>0 && empPositionCB.SelectedItem!=null && kadedraShifrCB.SelectedItem!=null )
                    return true;
                else
                {
                    MessageBox.Show("Заполните все поля");
                    return false;
                }
            }
        }

        private void empIdTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void empNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void empSecondNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void empPatronumicTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void kadedraShifrCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void empPositionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(empPositionCB.SelectedItem.ToString()== "зав. кафедрой")
            {
                zav = new zav_kafedri();
                zav.zav_id = emp.emp_id;
                emp.shef_id = emp.emp_id;
                shefIdCB.IsEnabled = false;
            }
            else if(empPositionCB.SelectedItem.ToString()=="инженер")
            {
                shefIdCB.IsEnabled=true;
                eng = new engineer();
                eng.emp_id = emp.emp_id;
            }    
            else
            {
                shefIdCB.IsEnabled = true;
                if(App.db.zav_kafedri.Any(x=>x.zav_id==emp.emp_id))
                {
                    zav = null;
                    shefIdCB.SelectedItem = null;
                    emp.shef_id = null;
                }
            }
            App.db.SaveChanges();

        }


        private void AddEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFields()==true)
            {
                emp.emp_salary = Convert.ToInt32(empSalaryTB.Text);
                emp.kafedra_shifr = kadedraShifrCB.Text;
                
                emp.emp_position = empPositionCB.Text;
                emp.shef_id = zav == null ? Convert.ToInt32(shefIdCB.Text) : emp.emp_id;
                if(App.IsPageEnable==true)
                {
                    emp.emp_name = $"{empSecondNameTB.Text} {empNameTB.Text.ToUpper().Remove(1)}. {empPatronumicTB.Text.ToUpper().Remove(1)}.";
                    App.db.employee.Add(emp);
                }
                if(zav!=null && !App.db.zav_kafedri.Any(x=>x.zav_id==zav.zav_id))
                {
                    zav.zav_id = emp.emp_id;
                    App.db.zav_kafedri.Add(zav);
                }
                App.db.SaveChanges();
                App.mainWindow.MainWindowFrame.GoBack();
                App.mainWindow.MainWindowFrame.RemoveBackEntry();
                App.IsPageEnable = false;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.NavigationService.GoBack();
            App.mainWindow.MainWindowFrame.RemoveBackEntry();
        }

        private void empSalaryTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsLetter(e.Text[0]))
                e.Handled = true;
        }

        private void empNameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void empSecondNameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void empPatronumicTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text[0]))
                e.Handled = true;
        }
    }
}
