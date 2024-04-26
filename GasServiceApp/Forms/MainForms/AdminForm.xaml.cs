using GasServiceApp.Classes;
using GasServiceApp.Pages;
using GasServiceApp.Pages.MainPages;
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

namespace GasServiceApp.Forms.MainForms {
    public partial class AdminForm : Window {
        public AdminForm() {
            InitializeComponent();
            MainFrame.Navigate(new MainAdminPage());
            Manager.MainFrame = MainFrame;
        }

        private void RightBorder_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new MainAdminPage());
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new UsersAdminPage());
        }

        private void btnApps_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AppsAdminPage());
        }

        private void btnTech_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new TechAdminPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e) {
            if (MainFrame.CanGoBack) btnBack.Visibility = Visibility.Visible;
            else btnBack.Visibility = Visibility.Hidden;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new ProfilePage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
