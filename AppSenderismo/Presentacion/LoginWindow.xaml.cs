﻿using System;
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

namespace AppSenderismo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly string _usuario = "admin";
        private readonly string _pass = "admin";

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
            if (TxtUsuario.Text.Equals(_usuario) && TxtPass.Password.Equals(_pass))
            {
                MainWindow mainWindow = new MainWindow();
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
