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
using Med.APIs;
using Med.Pages.Laborant;

namespace Med.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLaborantMain.xaml
    /// </summary>
    public partial class PageLaborantMain : Page
    {
        public PageLaborantMain()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Page));
        }

        private void BtnTakeBio_Click(object sender, RoutedEventArgs e)
        {
            FrameClass._mainFrame.Navigate(new PageProvideService());
        }
    }
}
