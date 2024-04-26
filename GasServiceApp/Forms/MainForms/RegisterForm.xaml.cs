using GasServiceApp.Database;
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
    public partial class RegisterForm : Window {
        public RegisterForm() {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            var login = txtBox_Login.Text;
            var pass = txtBox_Password.Text;
            var email = txtBox_Email.Text;
            var fullname = txtBox_Fullname.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(fullname)) {
                MessageBox.Show("Пожалуйста, заполните все поля перед регистрацией.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new GasServiceCenterEntities()) {
                if (db.Users.Any(u => u.Login == login)){
                    MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (db.Users.Any(u => u.Email == email)){
                    MessageBox.Show("Пользователь с таким email уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newUser = new Users {
                    Login = login,
                    Password = pass,
                    Email = email,
                    RoleID = 1,
                    Fullname = fullname,
                    NumberPhone = null,
                    VerifedID = 1,
                    Address = null,
                    ImagePreview = null
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                MessageBox.Show("Пользователь успешно зарегистрирован.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
