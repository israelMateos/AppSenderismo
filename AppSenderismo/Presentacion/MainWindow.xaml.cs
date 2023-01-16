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
using AppSenderismo.Dominio;

namespace AppSenderismo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Usuario _usuario;

        public MainWindow(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _usuario.UltimoAcceso = DateTime.Now;
            _usuario.Modificar();
            TxtNombreUsuario.Text = _usuario.Nombre + " " + _usuario.Apellidos;
            TxtEmailUsuario.Text = _usuario.Email;
            TxtTlfnUsuario.Text = _usuario.Telefono;
            TxtDniUsuario.Text = _usuario.Dni;
            TxtFechaAcceso.Text = _usuario.UltimoAcceso.ToString();
        }

        private List<String> ObtenerNombresRutas()
        {
            Ruta ruta = new Ruta();
            ruta.LeerTodas();
            List<string> nombresRutas = new List<string>();
            foreach (Ruta r in ruta.Dao.rutas)
            {
                nombresRutas.Add(r.Nombre);
            }
            return nombresRutas;
        }

        private void RellenarLstBoxRutas()
        {
            foreach (string nombreRuta in ObtenerNombresRutas())
            {
                LstBoxRutas.Items.Add(nombreRuta);
            }
        }

        private void TabCtrlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabRutas.IsSelected)
            {
                RellenarLstBoxRutas();
            }
        }

        private void TxtBuscarRutas_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = TxtBuscarRutas.Text;
            LstBoxRutas.Items.Clear();

            if (string.IsNullOrEmpty(busqueda))
            {
                RellenarLstBoxRutas();
            }
            else
            {
                IEnumerable<string> rutasFiltradas = ObtenerNombresRutas()
                    .Where(ruta => ruta.ToLower().Contains(busqueda.ToLower()));
                foreach (string ruta in rutasFiltradas)
                {
                    LstBoxRutas.Items.Add(ruta);
                }
            }
        }
    }
}
