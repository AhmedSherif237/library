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

namespace library
{
    /// <summary>
    /// Interaction logic for welcome.xaml
    /// </summary>
    public partial class welcome : Page
    {
        public welcome()
        {
            InitializeComponent();
        }
        private void userbutton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new user());
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new admin());
        }
    }
}
