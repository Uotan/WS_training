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
using System.Windows.Shapes;
using Med.APIs;
using Med.Windows;
namespace Med.Windows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        public CaptchaWindow()
        {
            InitializeComponent();
            CaptchaAPI captcha = new CaptchaAPI();
            captchaLabel.Content = captcha.GenerateCode();
        }
        
        private void captchaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (captchaTextBox.Text.Length == 6)
            {
                if (captchaTextBox.Text == captchaLabel.Content.ToString())
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Captcha введена неверно", "Captcha", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }
    }
}
