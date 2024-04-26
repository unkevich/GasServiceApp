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

namespace GasServiceApp.CustomControlls {
    public partial class TextBoxWithPlace : UserControl {
        public TextBoxWithPlace() {
            InitializeComponent();
        }
        public string PlaceHolder {
            get { return (string)GetValue(PlaceHolderPropery); }
            set { SetValue(PlaceHolderPropery, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolder. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderPropery =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(TextBoxWithPlace));


        public string Text {
            get { return (string)GetValue(TextPropery); }
            set { SetValue(TextPropery, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolder. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextPropery =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxWithPlace));


        public bool IsPassword {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolder. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPasswordProperty =
            DependencyProperty.Register("IsPassword", typeof(bool), typeof(TextBoxWithPlace));

        private void passbox_PasswordChanged(object sender, RoutedEventArgs e) {
            email.Text = passbox.Password;
        }
    }
}
