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
using Med.Models;
using Med.APIs;
using Med.Pages;
using System.Windows.Threading;

namespace Med.Windows
{
    public partial class MainWindow : Window
    {
        MeLabEntities medLabEntities = new MeLabEntities();
        users _user;
        user_types user_Types = new user_types();
        DispatcherTimer dt;
        public TimeSpan TimeLost = new TimeSpan(0, 10, 0);
        public MainWindow()
        {
            
        }
        public MainWindow(users user)
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            FrameClass._mainFrame = WindowFrame;
            //FrameClass._mainFrame.Navigate(new PageLaborantMain());
            _user = user;
            var user_TYPE = medLabEntities.user_types.FirstOrDefault(x => x.code == _user.type);
            userTypeLabel.Content = user_TYPE.user_type + " - " + _user.full_name;
            switch (_user.type)
            {
                case 1: FrameClass._mainFrame.Navigate(new PageBuhgalterMain()); break;
                case 2: FrameClass._mainFrame.Navigate(new PageLaborantMain()); break;
                case 3: FrameClass._mainFrame.Navigate(new PageLabSercherMain()); break;
                case 4: FrameClass._mainFrame.Navigate(new PageAdminMain()); break;
                default:
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            lblTime.Content = "Время сессии "+TimeLost.ToString();
            TimeLost = TimeLost.Subtract(new TimeSpan(0, 0, 1));
            if (TimeLost==(new TimeSpan(0,0,0)))
            {
                dt.Stop();
                MessageBox.Show("Пора бы передохнуть");
            }
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Frame_ContentRendered(object sender, EventArgs e)
        {

        }
    }
    }
