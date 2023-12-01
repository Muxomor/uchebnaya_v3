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
    /// Логика взаимодействия для ExamListPage.xaml
    /// </summary>
    public partial class ExamListPage : Page
    {
        public ExamListPage()
        {
            InitializeComponent();
            ExamDateSortCB.SelectedIndex = 0;
            Refresh();

        }
        private void Refresh()
        {
            exam[] examen = App.db.exam.ToArray();
            if (ExamDateSortCB.SelectedIndex != 0)
            {
                if (ExamDateSortCB.SelectedIndex == 1)
                {
                    examen = examen.OrderBy(x => x.exam_date).ToArray();
                }
                else
                {
                    examen=examen.OrderByDescending(x=>x.exam_date).ToArray();
                }
            }
            ExamListWP.Children.Clear();
            foreach (var item in examen)
            {
                ExamListWP.Children.Add(new ExamUserControl(item));
            }
        }

        private void ExamDateSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new AuthPage());
            App.mainWindow.MainWindowFrame.RemoveBackEntry();
        }
    }
}