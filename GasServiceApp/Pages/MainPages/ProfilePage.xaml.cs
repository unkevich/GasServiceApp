using GasServiceApp.Classes;
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

namespace GasServiceApp.Pages.MainPages {
    public partial class ProfilePage : Page {
        public ProfilePage() {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new InfoProfilePage());
        }

        private void btnTechData_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new TechDataProfilePage());
        }

        private void btnApps_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AppsProfilePage());
        }
    }
}
