using GasServiceApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GasServiceApp.Pages.AddEditPages {
    public partial class AddEditUserPage : Page {
        private Users _current = new Users();
        public AddEditUserPage(Users selected) {
            InitializeComponent();
            if (selected != null)
                _current = selected;
            DataContext = _current;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            StringBuilder errors = new StringBuilder();
            if (_current.Login == null) errors.AppendLine("Введите логин");
            if (_current.Password == null) errors.AppendLine("Введите пароль");
            if (_current.Email == null) errors.AppendLine("Введите почту");
            if (_current.Fullname == null) errors.AppendLine("Введите ФИО");
            if (_current.NumberPhone == null) errors.AppendLine("Введите номер телефона");
            if (_current.Address == null) errors.AppendLine("Введите адрес электронной почты");

            if (errors.Length > 0) { // выводим ошибку, если что-то есть
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.UserID == 0)
                GasServiceCenterEntities.GetContext().Users.Add(_current);
            try
            {
                GasServiceCenterEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
