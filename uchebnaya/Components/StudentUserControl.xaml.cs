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

namespace uchebnaya.Components
{
    /// <summary>
    /// Логика взаимодействия для StudentUserControl.xaml
    /// </summary>
    public partial class StudentUserControl : UserControl
    {
        ExamStudent exStudent;
        public StudentUserControl(ExamStudent exStudent)
        {
            InitializeComponent();
            this.exStudent = exStudent;
            this.DataContext = exStudent;
        }

        private void OcenkaTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(OcenkaTB.Text.Length > 0)
            {
                exStudent.exam_ocenka = Convert.ToInt32(OcenkaTB.Text);
            }
            else
            {
                exStudent.exam_ocenka = null;
            }
        }

        private void OcenkaTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0])|| Convert.ToInt32(e.Text)<1||Convert.ToInt32(e.Text)>5)
            {
                e.Handled = true;
            }
        }
    }
}
