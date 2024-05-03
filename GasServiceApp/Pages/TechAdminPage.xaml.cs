using GasServiceApp.Classes;
using GasServiceApp.Database;
using GasServiceApp.Pages.AddEditPages;
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

namespace GasServiceApp.Pages {
    public partial class TechAdminPage : Page {
        public TechAdminPage() {
            InitializeComponent();
            DGridTech.ItemsSource = GasServiceCenterEntities.GetContext().GasMeters.ToList();
        }
        // метод для добавления информации
        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AddEditTechPage());
        }
        // метод для удаления информации
        private void btnDelete_Click(object sender, RoutedEventArgs e) {

        }
        // метод для редактирования информации
        private void BtnEdit_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AddEditTechPage());
        }
    }
}
