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
    /// Логика взаимодействия для AddExamStudent.xaml
    /// </summary>
    public partial class AddExamStudent : Page
    {
        private ExamStudent exam_student;
        public AddExamStudent(exam exam)
        {
            InitializeComponent();
            exam_student = new ExamStudent();
            exam_student.exam_id = exam.exam_id;
            DataContext = exam_student;
            student[] selectedStudents = App.db.ExamStudent.Where(x => x.exam_id == exam_student.exam_id).Select(x => x.student).ToArray();
            studentNameCb.ItemsSource = App.db.student.ToArray().Except(selectedStudents).ToArray();
        }
        private void OcenkaTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OcenkaTB.Text.Length > 0)
            {
                exam_student.exam_ocenka = Convert.ToInt32(OcenkaTB.Text);
            }
            else
            {
                exam_student.exam_ocenka = null;
            }
        }
        private void OcenkaTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) || Convert.ToInt32(e.Text) < 1 || Convert.ToInt32(e.Text) > 5)
            {
                e.Handled = true;
            }
        }

        private bool CheckComboBox()
        {
            if (exam_student.student_id==null)
            {
                MessageBox.Show("Выберите студента");
                return false;
            }
            else
                return true;
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckComboBox()==true)
            {
                App.db.ExamStudent.Add(exam_student);
                App.db.SaveChanges();
                App.mainWindow.MainWindowFrame.Navigate(new ExamListPage());
            }
        }

        private void studentNameCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            exam_student.student_id = ((sender as ComboBox).SelectedItem as student).student_id;
        }
    }
}

