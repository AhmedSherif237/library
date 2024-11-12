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

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void userbutton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new User());
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin());
        }
    }
}
