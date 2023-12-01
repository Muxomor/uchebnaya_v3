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
    /// Логика взаимодействия для ExamUserControl.xaml
    /// </summary>
    public partial class ExamUserControl : UserControl
    {
        exam examen;
        
        public ExamUserControl(exam examen)
        {
            InitializeComponent();
            this.examen = examen;
            DataContext = examen;
            Refresh();
            
        }
        private void Refresh()
        {
            ExamStudent[] exam_student = App.db.ExamStudent.Where(x => x.exam_id == examen.exam_id).ToArray();
            if (StudentSortCB.SelectedIndex!=0)
            {
                if(StudentSortCB.SelectedIndex==1) 
                {
                    exam_student=exam_student.OrderBy(x=>x.student.student_name).ToArray();
                }
                else if(StudentSortCB.SelectedIndex==2)
                {
                    exam_student = exam_student.OrderByDescending(x => x.student.student_name).ToArray();
                }
            }
            if(StudentSearchTB.Text.Length>0)
            {
                exam_student = exam_student.Where(x=>x.student.student_name.ToLower().Contains(StudentSearchTB.Text.ToLower())).ToArray();
            }
            StudnetsWP.Children.Clear();
            foreach (ExamStudent item in exam_student)
            {
                StudnetsWP.Children.Add(new StudentUserControl(item));
            }

        }

        private void StudentSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void StudentSearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new AddExamStudent(examen));
        }
    }
}
