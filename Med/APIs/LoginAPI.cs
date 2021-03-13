using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Med.Models;
using Med.Windows;

namespace Med.APIs
{
    class LoginAPI
    {
        public string _login = null;
        string _password = null;
        int _loginCounter = 0;
        LoginWindow _loginWindow;
        public LoginAPI()
        {

        }
        public LoginAPI(TextBox loginTextBox, PasswordBox passwordPasswordBox, LoginWindow loginWindow)
        {
            _login = loginTextBox.Text;
            _password = passwordPasswordBox.Password;
            _loginWindow = loginWindow;
        }

        public void checkUser()
        {
            MedLabEntities medLabEntities = new MedLabEntities();
            var check = medLabEntities.users.FirstOrDefault(x => x.login == _login && x.password == _password);
            if (check==null)
            {
                _loginCounter++;
                MessageBox.Show("Неправильно введен логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                _login = "";
                _password = "";
            }
            if (check==null && _loginCounter>0)
            {
                goToCaptcha();
            }
        }

        public void goToCaptcha()
        {
            CaptchaWindow captchaWindow = new CaptchaWindow();
            captchaWindow.Show();
            if (true)
            {

            }
        }
    }
}
