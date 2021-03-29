using Med.Models;
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

namespace Med.Pages.Laborant
{
    /// <summary>
    /// Логика взаимодействия для PageProvideService.xaml
    /// </summary>
    public partial class PageProvideService : Page
    {
        wsr_practiceEntities1 context;
        int CodeB;
        public PageProvideService()
        {
            InitializeComponent();
            context = new wsr_practiceEntities1();
            cmbPatients.ItemsSource = context.patients.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass._mainFrame.Navigate(new PageLaborantMain());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            patients_blood H = new patients_blood { patient=cmbPatients.SelectedIndex+1,  barcode = CodeB, date = DateTime.UtcNow };
            context.patients_blood.Add(H);
            context.SaveChanges();
        }

        private void btnBarcode_Click(object sender, RoutedEventArgs e)
        {
            Random R = new Random();
            var AAA = context.patients_blood.OrderByDescending(x => x.code).FirstOrDefault().code;
            //string BarCode = DateTime.UtcNow.ToString();
            //BarCode = BarCode.Replace(".", string.Empty);
            //BarCode = BarCode.Replace(" ", string.Empty);
            //BarCode = BarCode.Replace(":", string.Empty);
            CodeB = AAA + R.Next(001, 999);
            tbBarcode.Text = CodeB.ToString();
        }
    }
}
