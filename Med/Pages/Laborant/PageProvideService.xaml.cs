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
        List<ComboBox> CMBlists = new List<ComboBox>();

        public PageProvideService()
        {
            InitializeComponent();
            context = new wsr_practiceEntities1();
            cmbPatients.ItemsSource = context.patients.ToList();
            serviceComboBox.ItemsSource = context.services.ToList();
            CMBlists.Add(serviceComboBox); 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass._mainFrame.Navigate(new PageLaborantMain());
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

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.ItemsSource = context.services.ToList();
            comboBox.DisplayMemberPath = "service";
            comboBox.Margin = new Thickness(170, 15, 110, 15);
            comboBox.Height = 35;
            comboBox.Width = 700;
            comboBox.FontSize = 18;
            comboBox.VerticalContentAlignment = VerticalAlignment.Center;
            servicesStackPanel.Children.Add(comboBox);
            CMBlists.Add(comboBox);
        }

        private void btnAddprovideService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                patients_blood H = new patients_blood { patient = cmbPatients.SelectedIndex + 1, barcode = CodeB, date = DateTime.UtcNow };
                context.patients_blood.Add(H);
                context.SaveChanges();

                for (int i = 0; i < CMBlists.Count; i++)
                {
                    var AAA = context.patients_blood.OrderByDescending(x => x.code).FirstOrDefault().code;
                    provide_services newPS = new provide_services { blood = AAA, service = CMBlists[i].SelectedIndex };
                    context.provide_services.Add(newPS);
                    context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbBarcode.Text=="")
            {

            }
        }
    }
}
