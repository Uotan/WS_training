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

namespace Med
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wsrPracticeEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new wsrPracticeEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string log;
            string pass;
            try
            {
                log = txtLogin.Text;
                pass = txtPass.Password;
                var A = context.users.FirstOrDefault(x => x.login == log && x.password == pass);
                if (A == null)
                {
                    MessageBox.Show("вход не выполнен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
