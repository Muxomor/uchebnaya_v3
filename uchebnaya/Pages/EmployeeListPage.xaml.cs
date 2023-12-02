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
    /// Логика взаимодействия для EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        employee emp;
        public static WrapPanel wrapPanel;
        public EmployeeListPage()
        {
            InitializeComponent();
            Refresh();
            wrapPanel = empWP;
        }

        private void empSearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void empNameSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            employee[] employees = App.db.employee.ToArray();
            if(empNameSortCB.SelectedIndex!=0)
            {
                if (empNameSortCB.SelectedIndex==1)
                {
                    employees = employees.OrderBy(x=>x.emp_name).ToArray();
                }
                else if(empNameSortCB.SelectedIndex==2)
                {
                    employees = employees.OrderByDescending(x=>x.emp_name).ToArray();
                }
            }
            if(empSearchTB.Text!="")
            {
                employees = employees.Where(x => x.emp_name.ToLower().Contains(empSearchTB.Text.ToLower())).ToArray();
            }

            empWP.Children.Clear();
            foreach(var item in employees)
            {
                empWP.Children.Add(new EmployeeUserControl(item));
            }
        }

        private void AddEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            App.IsPageEnable = true;
            App.mainWindow.MainWindowFrame.Navigate(new AddOrRedactEmployee(new employee()));
        }
    }
}
