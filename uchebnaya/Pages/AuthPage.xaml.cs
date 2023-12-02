using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

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
            loginTB.Focus();
            // Ссылка на XL таблицу
            string soucer_xl = "https://youtu.be/KTPbAY0UoH8?si=2VcwHdNsnVqEqq6T";
            // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                qrImg.Source = bitmapimage;
            }
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
                        App.mainWindow.MainWindowFrame.Navigate(new ExamListPage());
                    }
                    else if(empPosition== "зав. кафедрой")
                    {
                        MessageBox.Show($"Вы успешно вошли как {empPosition}");
                        App.mainWindow.MainWindowFrame.Navigate(new Uri("Pages/KafedraListPage.xaml", UriKind.Relative));
                    }
                    else if(empPosition=="инженер")
                    {
                        MessageBox.Show($"Вы успешно вошли как {empPosition}");
                        App.mainWindow.MainWindowFrame.Navigate(new Uri("Pages/EmployeeListPage.xaml",UriKind.Relative));
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
