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
using System.Windows.Threading;

namespace Med
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DispatcherTimer dt;
        public int BlockTime = 0;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;

        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            BlockTime++;
            if (BlockTime == 10)
            {
                dt.Stop();
                BlockTime = 0;
                loginTextBox.IsEnabled = true;
                passwordPasswordBox.IsEnabled = true;
                btnLog.IsEnabled = true;
            }
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            LoginAPI loginAPI = new LoginAPI(loginTextBox, passwordPasswordBox, this);
            if (CaptchaResult.RES == false)
            {
                dt.Start();
                loginTextBox.IsEnabled = false;
                passwordPasswordBox.IsEnabled = false;
                btnLog.IsEnabled = false;
            }
            //CaptchaWindow captchaWindow = new CaptchaWindow();
            //captchaWindow.ShowDialog();
            //this.Close();
            //loginAPI.checkUser();
        }
    }
}
