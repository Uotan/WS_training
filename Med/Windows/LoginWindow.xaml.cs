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
    public partial class LoginWindow : Window
    {
        bool L_check = false;
        bool P_check = false;
        DispatcherTimer dt;
        public int BlockTime = 11;
        public LoginWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;

        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            BlockTime--;
            btnLog.Content = BlockTime.ToString();
            if (BlockTime == 0)
            {
                dt.Stop();
                btnLog.Content = "ВХОД";
                BlockTime = 10;
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
        }

        private void passwordPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            P_check = true;
            if (passwordPasswordBox.Password == "")
            {
                P_check = false;
            }
            if (P_check==true&&L_check==true)
            {
                btnLog.IsEnabled = true;
            }
            else
            {
                btnLog.IsEnabled =false;
            }
        }

        private void loginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            L_check = true;
            if (loginTextBox.Text == "")
            {
               L_check = false;
            }
            if (P_check == true && L_check == true)
            {
                btnLog.IsEnabled = true;
            }
            else
            {
                btnLog.IsEnabled = false;
            }
        }
    }
}
