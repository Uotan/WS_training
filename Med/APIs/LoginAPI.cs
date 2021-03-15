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
        public int Logtry = 0;
        public LoginAPI()
        {

        }
        public LoginAPI(TextBox loginTextBox, PasswordBox passwordPasswordBox, LoginWindow loginWindow)
        {
            _login = loginTextBox.Text;
            _password = passwordPasswordBox.Password;
            loginWin = loginWindow;
            checkUser();
        }
        public void checkUser()
        {
            try
            {
                if (_login==""||_password=="")
                {
                    MessageBox.Show("Не введен логин или пароль");
                }
                else
                {

                    MeLabEntities medLabEntities = new MeLabEntities();
                    users check = medLabEntities.users.FirstOrDefault(x => x.login == _login && x.password == _password);
                    
                    if (check != null)
                    {
                        history_login H = new history_login { userLogin = _login, success = true, Time = DateTime.UtcNow };
                        medLabEntities.history_login.Add(H);
                        medLabEntities.SaveChanges();
                        createMain(check);
                    }
                    else
                    {
                        history_login H = new history_login { userLogin = _login, success = false, Time = DateTime.UtcNow };
                        medLabEntities.history_login.Add(H);
                        medLabEntities.SaveChanges();
                        MessageBox.Show("Неправильно введен логин или пароль!");
                        Logtry++;
                        if (Logtry >= 1)
                        {
                            CaptchaWindow captchaWindow = new CaptchaWindow();
                            captchaWindow.ShowDialog();
                            if (CaptchaResult.RES==false)
                            {
                                MessageBox.Show("Вход будет заблокирован на 10 секунд");
                            }
                            if (CaptchaResult.RES == true)
                            {
                                MessageBox.Show("CAPTCHA решена!");
                            }
                        }
                    }
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
