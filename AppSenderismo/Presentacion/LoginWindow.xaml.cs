using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AppSenderismo.Dominio;

namespace AppSenderismo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
            TxtPass.IsEnabled = false;
            BtnLogin.IsEnabled = false;
            TxtIncorrecto.Visibility = Visibility.Hidden;
        }

        private void TxtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUsuario.Text))
            {
                TxtPass.IsEnabled = true;
            }
            else
            {
                TxtPass.IsEnabled = false;
                BtnLogin.IsEnabled = false;
            }
        }

        private void TxtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            BtnLogin.IsEnabled = !string.IsNullOrEmpty(TxtPass.Password);
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario(TxtUsuario.Text, TxtPass.Password);
            usuario.Leer();
            if (!string.IsNullOrEmpty(usuario.Dni))
            {
                MainWindow mainWindow = new MainWindow(usuario);
                mainWindow.Show();
                Close();
            }
            else
            {
                TxtIncorrecto.Visibility = Visibility.Visible;
            }
        }
    }
}
