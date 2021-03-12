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
using Med.Models;
using Med.APIs;
using Med.Windows;

namespace Med
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginAPI loginAPI = new LoginAPI(loginTextBox, passwordPasswordBox, this);
            CaptchaWindow captchaWindow = new CaptchaWindow();
            captchaWindow.Show();
            this.Close();
            //loginAPI.checkUser();
        }
    }
}
