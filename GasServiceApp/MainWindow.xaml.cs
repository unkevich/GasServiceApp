using GasServiceApp.Database;
using GasServiceApp.Forms.MainForms;
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

namespace GasServiceApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void btnRecoveryPass_Click(object sender, RoutedEventArgs e) {
            RecoveryPassForm rpf = new RecoveryPassForm();
            this.Hide();
            rpf.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            RegisterForm rf = new RegisterForm();
            this.Hide();
            rf.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            GasServiceCenterEntities db = new GasServiceCenterEntities();
            var login = txtBox_Login.Text;
            var pass = txtBox_Password.Text;
            if (db.Users.Any(u => u.Login == login) == true) {
                foreach (var us in db.Users) {
                    if (us.Login == login) {
                        if (us.Password == pass) {
                            var role = db.Roles.Find(us.RoleID);
                            if (role.RoleName == "Клиент") {

                            }
                            else if (role.RoleName == "Оператор") {

                            }
                            else if (role.RoleName == "Администратор") {
                                AdminForm af = new AdminForm();
                                this.Hide();
                                af.Show();
                            }
                        } else MessageBox.Show("Вы ввкели некорректный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            } else MessageBox.Show("Пользователь не найден в базе данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
