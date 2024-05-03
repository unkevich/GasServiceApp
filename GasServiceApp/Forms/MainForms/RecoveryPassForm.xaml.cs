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
using System.Net;
using System.Net.Mail;

namespace GasServiceApp.Forms.MainForms {
    public partial class RecoveryPassForm : Window {

        private string recoveryCode = null;
        private string userEmail = null;
        private bool isCodeSent = false;

        public RecoveryPassForm() {
            InitializeComponent();
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }

        private void btnRecovery_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, был ли отправлен код для подтверждения
            if (!isCodeSent)
            {
                // Проверяем, введена ли электронная почта
                if (string.IsNullOrWhiteSpace(txtBox_Email.Text))
                {
                    MessageBox.Show("Пожалуйста, введите вашу электронную почту.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using (var db = new GasServiceCenterEntities())
                {
                    userEmail = txtBox_Email.Text;
                    // Проверяем, есть ли пользователь с такой электронной почтой в базе данных
                    var user = db.Users.FirstOrDefault(u => u.Email == userEmail);
                    if (user == null)
                    {
                        MessageBox.Show("Пользователя с такой электронной почтой не существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Генерируем код восстановления и отправляем его на почту
                    recoveryCode = GenerateRecoveryCode();
                    SendRecoveryCode(userEmail, recoveryCode);

                    MessageBox.Show("На вашу электронную почту был отправлен код для сброса пароля.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtBox_Code.Visibility = Visibility.Visible;
                    btnRecovery.Content = "Подтвердить код";
                    isCodeSent = true;
                    MessageBox.Show($"Код: {recoveryCode}");
                }
            }
            else
            {
                // Проверяем, введен ли код
                if (string.IsNullOrWhiteSpace(txtBox_Code.Text))
                {
                    MessageBox.Show("Пожалуйста, введите код для сброса пароля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Проверяем, совпадает ли введенный код с сгенерированным
                if (txtBox_Code.Text != recoveryCode)
                {
                    MessageBox.Show("Введенный код не совпадает с отправленным на вашу почту.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Сбрасываем пароль и отправляем новый пароль на почту
                using (var db = new GasServiceCenterEntities())
                {
                    var user = db.Users.FirstOrDefault(u => u.Email == userEmail);
                    if (user != null)
                    {
                        // Генерируем новый пароль
                        string newPassword = GeneratePassword();
                        // Сохраняем новый пароль в базе данных
                        user.Password = newPassword;
                        db.SaveChanges();
                        // Отправляем новый пароль на почту
                        SendNewPassword(userEmail, newPassword);
                        MessageBox.Show("Новый пароль отправлен на вашу электронную почту.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Сбрасываем поля и флаги
                        txtBox_Code.Text = "";
                        txtBox_Code.Visibility = Visibility.Hidden;
                        btnRecovery.Content = "Сбросить пароль";
                        isCodeSent = false;
                    }
                }
            }
        }

        private string GenerateRecoveryCode()
        {
            // Генерация кода для сброса пароля
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GeneratePassword()
        {
            // Генерация нового пароля
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SendRecoveryCode(string userEmail, string recoveryCode)
        {
            // Отправка кода на почту
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("ilyaunkevitch@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "Код для сброса пароля";
                mail.Body = $"Код для сброса пароля: {recoveryCode}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("ilyaunkevitch@gmail.com", "yourpassword");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки сообщения на почту: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SendNewPassword(string userEmail, string newPassword)
        {
            // Отправка нового пароля на почту (реализация отправки почты)
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("unkevich@vk.com");

                mail.From = new MailAddress("ilyaunkevitch@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "Новый пароль";
                mail.Body = $"Новый пароль: {newPassword}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("ilyaunkevitch@gmail.com", "propitanie2033metro76");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки сообщения на почту: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
