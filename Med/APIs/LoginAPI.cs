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
        LoginWindow loginWin;
        public LoginAPI()
        {

        }
        public LoginAPI(TextBox loginTextBox, PasswordBox passwordPasswordBox, LoginWindow loginWindow)
        {
            _login = loginTextBox.Text;
            _password = passwordPasswordBox.Password;
            loginWin = loginWindow;
        }
        public void checkUser()
        {
            try
            {
                MedLabEntities medLabEntities = new MedLabEntities();
                users check = medLabEntities.users.FirstOrDefault(x => x.login == _login && x.password == _password);
                if (check != null)
                {
                    createMain(check);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void createMain(users user)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            loginWin.Close();
        }
    }
}
