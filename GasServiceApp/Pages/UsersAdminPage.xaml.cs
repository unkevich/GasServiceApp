﻿using GasServiceApp.Classes;
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
            Manager.MainFrame.Navigate(new AddEditUserPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) {
            Manager.MainFrame.Navigate(new AddEditUserPage());
        }
    }
}