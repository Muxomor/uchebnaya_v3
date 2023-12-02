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
    /// Логика взаимодействия для EmployeeUserControl.xaml
    /// </summary>
    public partial class EmployeeUserControl : UserControl
    {
        employee emp;
        public EmployeeUserControl(employee emp)
        {
            InitializeComponent();
            this.emp = emp;
            this.DataContext=emp;
            if(emp.emp_position== "зав. кафедрой")
            {
                DeleteBtn.IsEnabled = false;
            }
        }

        private void empEditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new AddOrRedactEmployee(emp));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(emp.emp_position=="инженер")
            {
                App.db.engineer.Remove(emp.engineer);
            }
            App.db.employee.Remove(emp);
            EmployeeListPage.wrapPanel.Children.Remove(this);
            App.db.SaveChanges();
        }
    }
}
