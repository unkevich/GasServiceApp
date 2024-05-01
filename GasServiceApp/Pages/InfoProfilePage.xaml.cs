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

namespace GasServiceApp.Pages {
    public partial class InfoProfilePage : Page {
        public InfoProfilePage() {
            InitializeComponent();
            txt_login.Text = $"Логин: {Databank.Login}";
            txt_role.Text = $"Роль:  {Databank.Role}";
            txt_email.Text = $"Электронная почта:  {Databank.Email}";
            txt_number.Text = $"Номер телефона:  {Databank.NumberPhone}";
            txt_VerifedStatus.Text = $"Статус верификации:  {Databank.Verifed}";
            txt_Addres.Text = $"Адрес:  {Databank.Address}";
        }
    }
}
