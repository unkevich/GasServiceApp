using GasServiceApp.Classes;
using GasServiceApp.Database;
using GasServiceApp.Forms.MainForms;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace GasServiceApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        // функция для перемещения формы
        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        // кнопка для закрытия приложения
        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        // кнопка для показа формы сроса пароля
        private void btnRecoveryPass_Click(object sender, RoutedEventArgs e) {
            RecoveryPassForm rpf = new RecoveryPassForm();
            this.Hide();
            rpf.Show();
        }
        
        // кнопка для показа формы регистрации
        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            RegisterForm rf = new RegisterForm();
            this.Hide();
            rf.Show();
        }
        
        // метод авторизации
        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            GasServiceCenterEntities db = new GasServiceCenterEntities();
            var login = txtBox_Login.Text; // логин
            var pass = txtBox_Password.Text; // пароль
            if (db.Users.Any(u => u.Login == login) == true) { // если пользователь найден в бд
                foreach (var us in db.Users) {
                    if (us.Login == login) { // сравнение логина из бд с полем логина
                        if (us.Password == pass) { // сравнение пароля из бд с полем пароля
                            var role = db.Roles.Find(us.RoleID); // роль пользователя (Клиент, Оператор, Администратор)
                            var verf = db.VerifedStatus.Find(us.VerifedID); // статус верификации
                            // сохранение информации о пользователе
                            Databank.UserID = us.UserID;
                            Databank.Login = us.Login;
                            Databank.Password = us.Password;
                            Databank.Role = role.RoleName;
                            Databank.Email = us.Email;
                            Databank.Fullname = us.Fullname;
                            Databank.NumberPhone = us.NumberPhone;
                            Databank.Verifed = verf.Name;
                            Databank.Address = us.Address;
                            if (role.RoleName == "Клиент") { // открытие формы клиента
                                ClientForm cf = new ClientForm();
                                this.Hide();
                                cf.Show();
                            }
                            else if (role.RoleName == "Оператор") { // открытие формы оператора
                                AdminForm af = new AdminForm();
                                this.Hide();
                                af.Show();
                            }
                            else if (role.RoleName == "Администратор") { // отрытие формы администратора
                                AdminForm af = new AdminForm();
                                this.Hide();
                                af.Show();
                            } // если пользователь ввёл не правильный пароль
                        } else MessageBox.Show("Вы ввкели некорректный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } // если пользователь не найден в бд
            } else MessageBox.Show("Пользователь не найден в базе данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
