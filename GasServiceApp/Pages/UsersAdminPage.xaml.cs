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
    public partial class UsersAdminPage : Page {
        public UsersAdminPage() {
            InitializeComponent();
            DGridUsers.ItemsSource = GasServiceCenterEntities.GetContext().Users.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AddEditUserPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            var usersForRemoving = DGridUsers.SelectedItems.Cast<Users>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    GasServiceCenterEntities.GetContext().Users.RemoveRange(usersForRemoving);
                    GasServiceCenterEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    DGridUsers.ItemsSource = GasServiceCenterEntities.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AddEditUserPage((sender as Button).DataContext as Users));
        }
    }
}
