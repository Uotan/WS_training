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

namespace Med.Windows
{
    public partial class MainWindow : Window
    {
        MedLabEntities medLabEntities = new MedLabEntities();
        users _user;
        user_types user_Types = new user_types();
        public MainWindow()
        {

        }
        public MainWindow(users user)
        {
            InitializeComponent();
            _user = user;
            var usert = medLabEntities.user_types.FirstOrDefault(x => x.code == _user.type);
            userType.Content = usert.user_type + " - " + _user.full_name;
        }
    }
}
