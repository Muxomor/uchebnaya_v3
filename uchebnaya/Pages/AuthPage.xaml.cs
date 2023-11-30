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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loginTB.Text.Length != 0 )
            {
                if(App.db.employee.Any(x=>(x.emp_id).ToString()==loginTB.Text))
                {
                    string empPosition = App.db.employee.First(x=>(x.emp_id).ToString()==loginTB.Text).emp_position.ToString();
                    if (empPosition=="преподаватель")
                    {
                        MessageBox.Show($"Вы успешно вошли как {empPosition}");
                    }
                    else if(empPosition== "зав. кафедрой")
                    {
                        MessageBox.Show($"Вы успешно вошли как {empPosition}");
                        App.mainWindow.MainWindowFrame.Navigate(new Uri("Pages/KafedraListPage.xaml", UriKind.Relative));
                    }
                    else if(empPosition=="инженер")
                    {
                        MessageBox.Show($"Вы успешно вошли как {empPosition}");
                    }    
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
            }
            else
            {
                MessageBox.Show("Вы вошли как гость");
                App.mainWindow.MainWindowFrame.Navigate(new Uri("Pages/GuestPage.xaml",UriKind.Relative));
            }
        }

        private void loginTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                AuthBtn_Click(sender, e);
            }
        }
    }
}
