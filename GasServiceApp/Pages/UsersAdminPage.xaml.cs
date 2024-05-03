using GasServiceApp.Classes;
using GasServiceApp.Database;
using GasServiceApp.Pages.AddEditPages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GasServiceApp.Pages {
    public partial class UsersAdminPage : Page {
        public UsersAdminPage() {
            InitializeComponent();
            DGridUsers.ItemsSource = GasServiceCenterEntities.GetContext().Users.ToList(); // показ таблицы пользователей
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AddEditUserPage(null)); // открытие страницы с добавлением пользователя
        }

        // метод удаления пользователя
        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            var usersForRemoving = DGridUsers.SelectedItems.Cast<Users>().ToList();
            // вывод сообщения + проверка на нажатие Да или Нет
            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                try { // если исключение не сработало
                    GasServiceCenterEntities.GetContext().Users.RemoveRange(usersForRemoving); // удаление пользователя
                    GasServiceCenterEntities.GetContext().SaveChanges(); // сохранение информации
                    MessageBox.Show("Информация удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); // вывод сообщения
                    DGridUsers.ItemsSource = GasServiceCenterEntities.GetContext().Users.ToList(); // обновление таблицы
                }
                catch (Exception ex) { // если  исключение сработало, выводим сообщение
                    MessageBox.Show(ex.Message.ToString(), "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        
        private void BtnEdit_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AddEditUserPage((sender as Button).DataContext as Users)); // открытие страницы с редактированием пользователя
        }
    }
}
