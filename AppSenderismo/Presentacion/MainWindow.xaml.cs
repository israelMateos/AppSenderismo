using System;
using System.Text.RegularExpressions;
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
            try
            {
                ruta.LeerTodas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void RellenarLstBoxProvincias()
        {
            string[] provincias = {"Álava", "Albacete", "Alicante", "Almería",
                "Asturias", "Ávila", "Badajoz", "Barcelona", "Burgos", "Cáceres",
                "Cádiz", "Cantabria", "Castellón", "Ciudad Real", "Córdoba",
                "La Coruña", "Cuenca", "Gerona", "Granada", "Guadalajara",
                "Guipúzcoa", "Huelva", "Huesca", "Islas Baleares", "Jaén", "León",
                "Lérida", "Lugo", "Madrid", "Málaga", "Murcia", "Navarra",
                "Orense", "Palencia", "Las Palmas", "Pontevedra", "La Rioja",
                "Salamanca", "Segovia", "Sevilla", "Soria", "Tarragona",
                "Santa Cruz de Tenerife", "Teruel", "Toledo", "Valencia",
                "Valladolid", "Vizcaya", "Zamora", "Zaragoza"};
            foreach (string provincia in provincias)
            {
                CheckBox elemento = new CheckBox() {
                    Content = provincia, IsChecked = false};
                LstBoxProvincias.Items.Add(elemento);
            }
        }

        private void MarcarCasillasLstBoxProvincias(string[] provincias)
        {
            foreach (string provincia in provincias)
            {
                foreach (CheckBox elemento in LstBoxProvincias.Items)
                {
                    if (elemento.Content.ToString() == provincia)
                    {
                        elemento.IsChecked = true;
                    }
                }
            }
        }

        private void RellenarComboGuiaRutas()
        {
            Guia guia = new Guia();
            try
            {
                guia.LeerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            foreach (Guia g in guia.Dao.guias)
            {
                ComboGuiaRutas.Items.Add(g.Email);
            }
        }

        private void TabCtrlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (tabRutas.IsSelected)
                {
                    BtnLimpiarRuta_Click(sender, e);
                    LstBoxRutas.Items.Clear();
                    LstBoxProvincias.Items.Clear();
                    RellenarLstBoxRutas();
                    RellenarLstBoxProvincias();
                    RellenarComboGuiaRutas();
                }
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

        private void BtnLimpiarRuta_Click(object sender, RoutedEventArgs e)
        {
            LstBoxRutas.UnselectAll();
            TxtNombreRuta.Clear();
            LstBoxProvincias.Items.Clear();
            RellenarLstBoxProvincias();
            DateRuta.SelectedDate = null;
            TxtOrigenRuta.Clear();
            TxtDestinoRuta.Clear();
            ComboDificultadRutas.SelectedItem = null;
            ComboGuiaRutas.SelectedItem = null;
            TxtDuracionRuta.Clear();
            TxtAccesoRuta.Clear();
            TxtVueltaRuta.Clear();
            TxtMaterialRuta.Clear();
            CheckComerRuta.IsChecked = false;
            BtnAnadirRuta.IsEnabled = true;
            BtnModificarRuta.IsEnabled = false;
            BtnEliminarRuta.IsEnabled = false;
            TxtNombreRuta.IsEnabled = true;
        }

        private void LstBoxRutas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnAnadirRuta.IsEnabled = false;
            BtnModificarRuta.IsEnabled = true;
            BtnEliminarRuta.IsEnabled = true;

            if (LstBoxRutas.SelectedItem != null)
            {
                Ruta ruta = new Ruta(LstBoxRutas.SelectedItem.ToString());
                try
                {
                    ruta.Leer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                TxtNombreRuta.Text = ruta.Nombre;
                LstBoxProvincias.Items.Clear();
                RellenarLstBoxProvincias();
                MarcarCasillasLstBoxProvincias(Regex.Split(ruta.Provincias, ",\\s*"));
                DateRuta.SelectedDate = ruta.Fecha;
                TxtOrigenRuta.Text = ruta.Origen;
                TxtDestinoRuta.Text = ruta.Destino;
                ComboDificultadRutas.SelectedValue = ruta.Dificultad;
                if (ruta.Guia != null)
                {
                    ComboGuiaRutas.SelectedItem = ComboGuiaRutas.Items.OfType<string>()
                        .FirstOrDefault(x => x == ruta.Guia.Email); ;
                }
                else
                {
                    ComboGuiaRutas.SelectedItem = null;
                }
                TxtDuracionRuta.Text = ruta.DuracionEstimada.ToString();
                TxtAccesoRuta.Text = ruta.FormaAcceso;
                TxtVueltaRuta.Text = ruta.FormaSalida;
                TxtMaterialRuta.Text = ruta.MaterialNecesario;
                CheckComerRuta.IsChecked = ruta.ComidaEnRuta;
                TxtNombreRuta.IsEnabled = false;
            }
        }

        private void BtnEliminarRuta_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que quieres eliminar la ruta?",
                "Confirmar Eliminación", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Ruta ruta = new Ruta(TxtNombreRuta.Text);
                try
                {
                    int rutasEliminadas;
                    if ((rutasEliminadas = ruta.Eliminar()) != 1)
                    {
                        MessageBox.Show("Se han eliminado " + rutasEliminadas +
                            " rutas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LstBoxRutas.Items.RemoveAt(LstBoxRutas.SelectedIndex);
                    BtnLimpiarRuta_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
