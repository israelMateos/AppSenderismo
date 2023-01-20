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

        private bool _espanol;

        public LoginWindow()
        {
            InitializeComponent();
            _espanol = true;
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
                Window loginWindow = GetWindow(this);

                Window mainWindow = new MainWindow(usuario)
                {
                    Width = loginWindow.Width,
                    Height = loginWindow.Height,
                    Left = loginWindow.Left,
                    Top = loginWindow.Top,
                    WindowState = loginWindow.WindowState
                };

                loginWindow.Close();
                mainWindow.Show();
            }
            else
            {
                TxtIncorrecto.Visibility = Visibility.Visible;
            }
        }

        private void BtnIdioma_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem espanolItem = new MenuItem { Header = "Español" };
            MenuItem inglesItem = new MenuItem { Header = "Inglés" };
            if (!_espanol)
            {
                espanolItem.Header = "Spanish" ;
                inglesItem.Header = "English" ;
            }

            espanolItem.Click += EspanolItem_Click;
            contextMenu.Items.Add(espanolItem);

            inglesItem.Click += InglesItem_Click;
            contextMenu.Items.Add(inglesItem);

            contextMenu.IsOpen = true;
        }
        private void EspanolItem_Click(object sender, RoutedEventArgs e)
        {
            _espanol = true;
            TxtBoxUsuario.Text = "Usuario";
            TxtBoxPass.Text = "Contraseña";
            TxtIncorrecto.Text = "Combinación usuario/contraseña incorrecta";
            BtnLogin.Content = "Iniciar sesión";
        }

        private void InglesItem_Click(object sender, RoutedEventArgs e)
        {
            _espanol = false;
            TxtBoxUsuario.Text = "Username";
            TxtBoxPass.Text = "Password";
            TxtIncorrecto.Text = "Incorrect username/password combination";
            BtnLogin.Content = "Login";
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {
            Window ayudaWindow = new AyudaWindow();
            ayudaWindow.Show();
        }
    }
}
