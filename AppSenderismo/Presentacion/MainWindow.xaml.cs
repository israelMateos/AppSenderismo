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
                if (tabGuias.IsSelected)
                {
                    BtnLimpiarGuia_Click(sender, e);
                    LstBoxGuias.Items.Clear();
                    LstBoxIdiomas.Items.Clear();
                    RellenarLstBoxGuias();
                    RellenarLstBoxIdiomas();
                }
                if (tabExcursionista.IsSelected)
                {
                    BtnLimpiarExc_Click(sender, e);
                    LstBoxExc.Items.Clear();
                    RellenarLstBoxExc();
                    LstBoxRutasPlaneadas.Items.Clear();
                    LstBoxRutasRealizadas.Items.Clear();
                    RellenarLstBoxRutasExc();
                }
                if (tabPromocionesTematicas.IsSelected)
                {
                    BtnLimpiarPromo_Click(sender, e);
                    LstBoxPromo.Items.Clear();
                    RellenarLstBoxPromos();
                }
            }
        }

        private List<string> ObtenerNombresRutas()
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
            foreach (Ruta r in ruta.Dao.Rutas)
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
            foreach (Guia g in guia.Dao.Guias)
            {
                ComboGuiaRutas.Items.Add(g.Email);
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

        private void BtnModificarRuta_Click(object sender, RoutedEventArgs e)
        {
            bool algunaMarcada = false;
            foreach (CheckBox elemento in LstBoxProvincias.Items)
            {
                if (elemento.IsChecked == true)
                {
                    algunaMarcada = true;
                    break;
                }
            }
            if (!algunaMarcada || string.IsNullOrEmpty(TxtOrigenRuta.Text) ||
                string.IsNullOrEmpty(TxtDestinoRuta.Text) ||
                string.IsNullOrEmpty(TxtDuracionRuta.Text) ||
                string.IsNullOrEmpty(TxtAccesoRuta.Text) ||
                string.IsNullOrEmpty(TxtVueltaRuta.Text) ||
                string.IsNullOrEmpty(TxtMaterialRuta.Text) ||
                DateRuta.SelectedDate == null ||
                ComboDificultadRutas.SelectedIndex == -1)
            {
                TxtFalloAnadirRuta.Visibility = Visibility.Visible;
            }
            else
            {
                TxtFalloAnadirRuta.Visibility = Visibility.Hidden;
                if (MessageBox.Show("¿Estás seguro de que quieres modificar la ruta?",
                    "Confirmar Modificación", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    string provincias = "";
                    foreach (CheckBox elemento in LstBoxProvincias.Items)
                    {
                        if (elemento != null && (elemento.IsChecked ?? false))
                        {
                            provincias += elemento.Content.ToString() + ",";
                        }
                    }
                    if (provincias != "")
                    {
                        provincias = provincias.Substring(0, provincias.Length - 1);
                    }
                    Guia guia = null;
                    if (ComboGuiaRutas.SelectedItem != null)
                    {
                        guia = new Guia(ComboGuiaRutas.SelectedItem.ToString());
                        guia.Leer();
                    }
                    Ruta ruta = new Ruta(TxtNombreRuta.Text, provincias,
                        DateRuta.SelectedDate.Value, TxtOrigenRuta.Text,
                        TxtDestinoRuta.Text, ComboDificultadRutas.Text,
                        int.Parse(TxtDuracionRuta.Text), TxtAccesoRuta.Text,
                        TxtVueltaRuta.Text, TxtMaterialRuta.Text,
                        CheckComerRuta.IsChecked ?? false, guia);
                    try
                    {
                        int rutasModificadas;
                        if ((rutasModificadas = ruta.Modificar()) != 1)
                        {
                            MessageBox.Show("Se han modificado " + rutasModificadas +
                                " rutas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        BtnLimpiarRuta_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void BtnAnadirRuta_Click(object sender, RoutedEventArgs e)
        {
            bool algunaMarcada = false;
            foreach (CheckBox elemento in LstBoxProvincias.Items)
            {
                if (elemento.IsChecked == true)
                {
                    algunaMarcada = true;
                    break;
                }
            }
            if (!algunaMarcada || string.IsNullOrEmpty(TxtOrigenRuta.Text) ||
                string.IsNullOrEmpty(TxtDestinoRuta.Text) ||
                string.IsNullOrEmpty(TxtDuracionRuta.Text) ||
                string.IsNullOrEmpty(TxtAccesoRuta.Text) ||
                string.IsNullOrEmpty(TxtVueltaRuta.Text) ||
                string.IsNullOrEmpty(TxtMaterialRuta.Text) ||
                DateRuta.SelectedDate == null ||
                ComboDificultadRutas.SelectedIndex == -1)
            {
                TxtFalloAnadirRuta.Visibility = Visibility.Visible;
            }
            else
            {
                TxtFalloAnadirRuta.Visibility = Visibility.Hidden;
                string provincias = "";
                foreach (CheckBox elemento in LstBoxProvincias.Items)
                {
                    if (elemento != null && (elemento.IsChecked ?? false))
                    {
                        provincias += elemento.Content.ToString() + ",";
                    }
                }
                if (provincias != "")
                {
                    provincias = provincias.Substring(0, provincias.Length - 1);
                }
                Guia guia = null;
                if (ComboGuiaRutas.SelectedItem != null)
                {
                    guia = new Guia(ComboGuiaRutas.SelectedItem.ToString());
                    guia.Leer();
                }
                Ruta ruta = new Ruta(TxtNombreRuta.Text, provincias,
                    DateRuta.SelectedDate.Value, TxtOrigenRuta.Text,
                    TxtDestinoRuta.Text, ComboDificultadRutas.Text,
                    int.Parse(TxtDuracionRuta.Text), TxtAccesoRuta.Text,
                    TxtVueltaRuta.Text, TxtMaterialRuta.Text,
                    CheckComerRuta.IsChecked ?? false, guia);
                try
                {
                    int rutasInsertadas;
                    if ((rutasInsertadas = ruta.Insertar()) != 1)
                    {
                        MessageBox.Show("Se han añadido " + rutasInsertadas +
                            " rutas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    BtnLimpiarRuta_Click(sender, e);
                    LstBoxRutas.Items.Clear();
                    RellenarLstBoxRutas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private List<string> ObtenerEmailsGuias()
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
            List<string> emailsGuias = new List<string>();
            foreach (Guia g in guia.Dao.Guias)
            {
                emailsGuias.Add(g.Email);
            }
            return emailsGuias;
        }

        private void RellenarLstBoxGuias()
        {
            foreach (string emailGuia in ObtenerEmailsGuias())
            {
                LstBoxGuias.Items.Add(emailGuia);
            }
        }

        private void TxtBuscarGuias_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = TxtBuscarGuias.Text;
            LstBoxGuias.Items.Clear();

            if (string.IsNullOrEmpty(busqueda))
            {
                RellenarLstBoxGuias();
            }
            else
            {
                IEnumerable<string> guiasFiltrados = ObtenerEmailsGuias()
                    .Where(guia => guia.ToLower().Contains(busqueda.ToLower()));
                foreach (string guia in guiasFiltrados)
                {
                    LstBoxGuias.Items.Add(guia);
                }
            }
        }

        private void RellenarLstBoxIdiomas()
        {
            string[] idiomas = { "Árabe", "Chino", "Español", "Francés",
                "Alemán", "Inglés", "Italiano", "Coreano", "Japonés",
                "Portugués", "Ruso" };
            foreach (string idioma in idiomas)
            {
                CheckBox elemento = new CheckBox() {
                    Content = idioma, IsChecked = false};
                LstBoxIdiomas.Items.Add(elemento);
            }
        }

        private void MarcarCasillasLstBoxIdiomas(string[] idiomas)
        {
            foreach (string idioma in idiomas)
            {
                foreach (CheckBox elemento in LstBoxIdiomas.Items)
                {
                    if (elemento.Content.ToString() == idioma)
                    {
                        elemento.IsChecked = true;
                    }
                }
            }
        }

        private void RellenarLstBoxRutasGuia(Guia guia)
        {
            foreach (Ruta ruta in guia.LeerRutas())
            {
                LstBoxRutasGuia.Items.Add(ruta.Nombre);
            }
        }

        private void BtnLimpiarGuia_Click(object sender, RoutedEventArgs e)
        {
            LstBoxGuias.UnselectAll();
            TxtNombreGuia.Clear();
            LstBoxIdiomas.Items.Clear();
            RellenarLstBoxIdiomas();
            TxtApellidosGuia.Clear();
            TxtTelefonosGuia.Clear();
            TxtCorreosGuia.Clear();
            TxtRestriccionesGuia.Clear();
            LstBoxRutasGuia.Items.Clear();
            TxtPuntuacionGuia.Clear();
            BtnAnadirRuta.IsEnabled = true;
            BtnModificarRuta.IsEnabled = false;
            BtnEliminarRuta.IsEnabled = false;
        }

        private void LstBoxGuias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnAnadirGuia.IsEnabled = false;
            BtnModificarGuia.IsEnabled = true;
            BtnEliminarGuia.IsEnabled = true;

            if (LstBoxGuias.SelectedItem != null)
            {
                Guia guia = new Guia(LstBoxGuias.SelectedItem.ToString());
                try
                {
                    guia.Leer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                TxtNombreGuia.Text = guia.Nombre;
                LstBoxIdiomas.Items.Clear();
                RellenarLstBoxIdiomas();
                MarcarCasillasLstBoxIdiomas(Regex.Split(guia.Idiomas, ",\\s*"));
                TxtApellidosGuia.Text = guia.Apellidos;
                TxtTelefonosGuia.Text = guia.Telefono;
                TxtCorreosGuia.Text = guia.Email;
                TxtRestriccionesGuia.Text = guia.Restricciones;
                LstBoxRutasGuia.Items.Clear();
                RellenarLstBoxRutasGuia(guia);
                TxtPuntuacionGuia.Text = guia.Puntuacion.ToString();
            }
        }

        private void BtnAnadirGuia_Click(object sender, RoutedEventArgs e)
        {
            bool algunaMarcada = false;
            foreach (CheckBox elemento in LstBoxIdiomas.Items)
            {
                if (elemento.IsChecked == true)
                {
                    algunaMarcada = true;
                    break;
                }
            }
            if (!algunaMarcada || string.IsNullOrEmpty(TxtNombreGuia.Text) ||
                string.IsNullOrEmpty(TxtApellidosGuia.Text) ||
                string.IsNullOrEmpty(TxtTelefonosGuia.Text) ||
                string.IsNullOrEmpty(TxtCorreosGuia.Text) ||
                string.IsNullOrEmpty(TxtPuntuacionGuia.Text) ||
                string.IsNullOrEmpty(TxtRestriccionesGuia.Text))
            {
                TxtFalloAnadirGuia.Visibility = Visibility.Visible;
            }
            else
            {
                TxtFalloAnadirGuia.Visibility = Visibility.Hidden;
                string idiomas = "";
                foreach (CheckBox elemento in LstBoxIdiomas.Items)
                {
                    if (elemento != null && (elemento.IsChecked ?? false))
                    {
                        idiomas += elemento.Content.ToString() + ",";
                    }
                }
                if (idiomas != "")
                {
                    idiomas = idiomas.Substring(0, idiomas.Length - 1);
                }
                Guia guia = new Guia(TxtNombreGuia.Text, TxtApellidosGuia.Text,
                    TxtTelefonosGuia.Text, TxtCorreosGuia.Text, idiomas,
                    TxtRestriccionesGuia.Text, int.Parse(TxtPuntuacionGuia.Text));
                try
                {
                    int guiasInsertados;
                    if ((guiasInsertados = guia.Insertar()) != 1)
                    {
                        MessageBox.Show("Se han añadido " + guiasInsertados +
                            " rutas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    BtnLimpiarGuia_Click(sender, e);
                    LstBoxGuias.Items.Clear();
                    RellenarLstBoxGuias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEliminarGuia_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que quieres eliminar el guía?",
                "Confirmar Eliminación", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Guia guia = new Guia(TxtCorreosGuia.Text);
                try
                {
                    int guiasEliminadas;
                    if ((guiasEliminadas = guia.Eliminar()) != 1)
                    {
                        MessageBox.Show("Se han eliminado " + guiasEliminadas +
                            " guías.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LstBoxGuias.Items.RemoveAt(LstBoxGuias.SelectedIndex);
                    BtnLimpiarGuia_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnModificarGuia_Click(object sender, RoutedEventArgs e)
        {
            bool algunaMarcada = false;
            foreach (CheckBox elemento in LstBoxIdiomas.Items)
            {
                if (elemento.IsChecked == true)
                {
                    algunaMarcada = true;
                    break;
                }
            }
            if (!algunaMarcada || string.IsNullOrEmpty(TxtNombreGuia.Text) ||
                string.IsNullOrEmpty(TxtApellidosGuia.Text) ||
                string.IsNullOrEmpty(TxtTelefonosGuia.Text) ||
                string.IsNullOrEmpty(TxtCorreosGuia.Text) ||
                string.IsNullOrEmpty(TxtPuntuacionGuia.Text) ||
                string.IsNullOrEmpty(TxtRestriccionesGuia.Text))
            {
                TxtFalloAnadirGuia.Visibility = Visibility.Visible;
            }
            else
            {
                TxtFalloAnadirGuia.Visibility = Visibility.Hidden;
                if (MessageBox.Show("¿Estás seguro de que quieres modificar el guía?",
                    "Confirmar Modificación", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    string idiomas = "";
                    foreach (CheckBox elemento in LstBoxIdiomas.Items)
                    {
                        if (elemento != null && (elemento.IsChecked ?? false))
                        {
                            idiomas += elemento.Content.ToString() + ",";
                        }
                    }
                    if (idiomas != "")
                    {
                        idiomas = idiomas.Substring(0, idiomas.Length - 1);
                    }
                    try
                    {
                        // Para mantener el ID en caso de que se cambien todos los campos
                        Guia guia = new Guia(LstBoxGuias.SelectedItem.ToString());
                        guia.Leer();
                        guia = new Guia(guia.Id, TxtNombreGuia.Text, TxtApellidosGuia.Text,
                            TxtTelefonosGuia.Text, TxtCorreosGuia.Text, idiomas,
                            TxtRestriccionesGuia.Text, int.Parse(TxtPuntuacionGuia.Text));
                        int guiasModificadas;
                        if ((guiasModificadas = guia.Modificar()) != 1)
                        {
                            MessageBox.Show("Se han modificado " + guiasModificadas +
                                " guías.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        LstBoxGuias.Items.Clear();
                        RellenarLstBoxGuias();
                        BtnLimpiarGuia_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private List<string> ObtenerItemsLstBoxExc()
        {
            Excursionista excursionista = new Excursionista();
            try
            {
                excursionista.LeerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            List<string> nombreApellidosExcursionistas = new List<string>();
            foreach (Excursionista e in excursionista.Dao.Excursionistas)
            {
                nombreApellidosExcursionistas.Add(e.Nombre + " " + e.Apellidos
                    + " (" + e.Telefono + ")");
            }
            return nombreApellidosExcursionistas;
        }

        private void RellenarLstBoxExc()
        {
            foreach (string itemExcursionista in ObtenerItemsLstBoxExc())
            {
                LstBoxExc.Items.Add(itemExcursionista);
            }
        }

        private void TxtBuscarExc_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = TxtBuscarExc.Text;
            LstBoxExc.Items.Clear();

            if (string.IsNullOrEmpty(busqueda))
            {
                RellenarLstBoxExc();
            }
            else
            {
                IEnumerable<string> excFiltrados = ObtenerItemsLstBoxExc()
                    .Where(exc => exc.ToLower().Contains(busqueda.ToLower()));
                foreach (string exc in excFiltrados)
                {
                    LstBoxExc.Items.Add(exc);
                }
            }
        }

        private void RellenarLstBoxRutasExc()
        {
            foreach (string nombreRuta in ObtenerNombresRutas())
            {
                CheckBox elemento = new CheckBox() {
                    Content = nombreRuta, IsChecked = false};
                Ruta ruta = new Ruta(nombreRuta);
                ruta.Leer();
                if (DateTime.Compare(ruta.Fecha, DateTime.Today) > 0)
                {
                    LstBoxRutasPlaneadas.Items.Add(elemento);
                }
                else
                {
                    LstBoxRutasRealizadas.Items.Add(elemento);
                }
            }
        }

        private void MarcarCasillasLstBoxRutasPlaneadas(List<string> rutas)
        {
            foreach (string ruta in rutas)
            {
                foreach (CheckBox elemento in LstBoxRutasPlaneadas.Items)
                {
                    if (elemento.Content.ToString() == ruta)
                    {
                        elemento.IsChecked = true;
                    }
                }
            }
        }

        private void MarcarCasillasLstBoxRutasRealizadas(List<string> rutas)
        {
            foreach (string ruta in rutas)
            {
                foreach (CheckBox elemento in LstBoxRutasRealizadas.Items)
                {
                    if (elemento.Content.ToString() == ruta)
                    {
                        elemento.IsChecked = true;
                    }
                }
            }
        }

        private void LstBoxExc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnAnadirExc.IsEnabled = false;
            BtnModificarExc.IsEnabled = true;
            BtnEliminarExc.IsEnabled = true;

            if (LstBoxExc.SelectedItem != null)
            {
                string tlfnExcursionista = LstBoxExc.SelectedItem.ToString().Split('(', ')')[1];
                Excursionista excursionista = new Excursionista(tlfnExcursionista);
                try
                {
                    excursionista.Leer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                TxtNombreExc.Text = excursionista.Nombre;
                TxtApellidosExc.Text = excursionista.Apellidos;
                TxtTlfnExc.Text = excursionista.Telefono;
                TxtEdadExc.Text = excursionista.Edad.ToString();
                LstBoxRutasPlaneadas.Items.Clear();
                LstBoxRutasRealizadas.Items.Clear();
                RellenarLstBoxRutasExc();
                List<string> rutasPlaneadas = new List<string>();
                List<string> rutasRealizadas = new List<string>();
                foreach (Ruta ruta in excursionista.RutasPlaneadas)
                {
                    rutasPlaneadas.Add(ruta.Nombre);
                }
                foreach (Ruta ruta in excursionista.RutasRealizadas)
                {
                    rutasRealizadas.Add(ruta.Nombre);
                }
                MarcarCasillasLstBoxRutasPlaneadas(rutasPlaneadas);
                MarcarCasillasLstBoxRutasRealizadas(rutasRealizadas);
            }
        }

        private void BtnLimpiarExc_Click(object sender, RoutedEventArgs e)
        {
            LstBoxExc.UnselectAll();
            TxtNombreExc.Clear();
            TxtApellidosExc.Clear();
            TxtTlfnExc.Clear();
            TxtEdadExc.Clear();
            LstBoxRutasPlaneadas.Items.Clear();
            LstBoxRutasRealizadas.Items.Clear();
            RellenarLstBoxRutasExc();
            BtnAnadirExc.IsEnabled = true;
            BtnModificarExc.IsEnabled = false;
            BtnEliminarExc.IsEnabled = false;
        }

        private void BtnAnadirExc_Click(object sender, RoutedEventArgs e)
        {
            bool algunaPlaneadaMarcada = false;
            foreach (CheckBox elemento in LstBoxRutasPlaneadas.Items)
            {
                if (elemento.IsChecked == true)
                {
                    algunaPlaneadaMarcada = true;
                    break;
                }
            }
            bool algunaRealizadaMarcada = false;
            foreach (CheckBox elemento in LstBoxRutasRealizadas.Items)
            {
                if (elemento.IsChecked == true)
                {
                    algunaRealizadaMarcada = true;
                    break;
                }
            }
            if(string.IsNullOrEmpty(TxtNombreExc.Text) ||
                string.IsNullOrEmpty(TxtApellidosExc.Text) ||
                string.IsNullOrEmpty(TxtTlfnExc.Text) ||
                string.IsNullOrEmpty(TxtEdadExc.Text))
            {
                TxtFalloAnadirExc.Visibility = Visibility.Visible;
            }
            else
            {
                TxtFalloAnadirExc.Visibility = Visibility.Hidden;
                Excursionista excursionista = new Excursionista(TxtNombreExc.Text,
                    TxtApellidosExc.Text, TxtTlfnExc.Text, int.Parse(TxtEdadExc.Text));
                List<Ruta> rutasPlaneadas = new List<Ruta>();
                List<Ruta> rutasRealizadas = new List<Ruta>();
                if (algunaPlaneadaMarcada)
                {
                    foreach (CheckBox elemento in LstBoxRutasPlaneadas.Items)
                    {
                        if (elemento != null && (elemento.IsChecked ?? false))
                        {
                            Ruta ruta = new Ruta(elemento.Content.ToString());
                            ruta.Leer();
                            rutasPlaneadas.Add(ruta);
                        }
                    }
                }
                if (algunaRealizadaMarcada)
                {
                    foreach (CheckBox elemento in LstBoxRutasRealizadas.Items)
                    {
                        if (elemento != null && (elemento.IsChecked ?? false))
                        {
                            Ruta ruta = new Ruta(elemento.Content.ToString());
                            ruta.Leer();
                            rutasRealizadas.Add(ruta);
                        }
                    }
                }
                try
                {
                    int excursionistasInsertados;
                    if ((excursionistasInsertados = excursionista.Insertar()) != 1)
                    {
                        MessageBox.Show("Se han añadido " + excursionistasInsertados +
                            " rutas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (algunaPlaneadaMarcada || algunaRealizadaMarcada)
                    {
                        excursionista.Leer();
                        excursionista.RutasRealizadas = rutasRealizadas;
                        excursionista.RutasPlaneadas = rutasPlaneadas;
                        int realizarRutaInsertados;
                        if ((realizarRutaInsertados = excursionista.InsertarRutas()) < 1)
                        {
                            MessageBox.Show("Se han insertado " + realizarRutaInsertados +
                                " rutas.", "Error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                    BtnLimpiarExc_Click(sender, e);
                    LstBoxExc.Items.Clear();
                    RellenarLstBoxExc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEliminarExc_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que quieres eliminar el excursionista?",
                "Confirmar Eliminación", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Excursionista excursionista =
                    new Excursionista(LstBoxExc.SelectedItem.ToString().Split('(', ')')[1]);

                bool algunaMarcada = false;
                foreach (CheckBox elemento in LstBoxRutasPlaneadas.Items)
                {
                    if (elemento.IsChecked == true)
                    {
                        algunaMarcada = true;
                        break;
                    }
                }
                if (!algunaMarcada)
                {
                    foreach (CheckBox elemento in LstBoxRutasRealizadas.Items)
                    {
                        if (elemento.IsChecked == true)
                        {
                            algunaMarcada = true;
                            break;
                        }
                    }
                }

                try
                {
                    int excursionistasEliminados;
                    if (algunaMarcada)
                    {
                        excursionista.Leer();
                        int realizarRutaEliminados;
                        if ((realizarRutaEliminados = excursionista.EliminarRutas()) < 1)
                        {
                            MessageBox.Show("Se han eliminado " + realizarRutaEliminados +
                                " excursionistas.", "Error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                    if ((excursionistasEliminados = excursionista.Eliminar()) != 1)
                    {
                        MessageBox.Show("Se han eliminado " + excursionistasEliminados +
                            " excursionistas.", "Error", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    LstBoxExc.Items.RemoveAt(LstBoxExc.SelectedIndex);
                    BtnLimpiarExc_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnModificarExc_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TxtNombreExc.Text) ||
                string.IsNullOrEmpty(TxtApellidosExc.Text) ||
                string.IsNullOrEmpty(TxtTlfnExc.Text) ||
                string.IsNullOrEmpty(TxtEdadExc.Text))
            {
                TxtFalloAnadirExc.Visibility = Visibility.Visible;
            }
            else
            {
                TxtFalloAnadirExc.Visibility = Visibility.Hidden;
                Excursionista excursionista
                    = new Excursionista(LstBoxExc.SelectedItem.ToString().Split('(', ')')[1]);
                excursionista.Leer();
                excursionista = new Excursionista(excursionista.Id, TxtNombreExc.Text,
                    TxtApellidosExc.Text, TxtTlfnExc.Text, int.Parse(TxtEdadExc.Text));
                List<Ruta> rutasPlaneadas = new List<Ruta>();
                List<Ruta> rutasRealizadas = new List<Ruta>();
                foreach (CheckBox elemento in LstBoxRutasPlaneadas.Items)
                {
                    if (elemento != null && (elemento.IsChecked ?? false))
                    {
                        Ruta ruta = new Ruta(elemento.Content.ToString());
                        ruta.Leer();
                        rutasPlaneadas.Add(ruta);
                    }
                }
                foreach (CheckBox elemento in LstBoxRutasRealizadas.Items)
                {
                    if (elemento != null && (elemento.IsChecked ?? false))
                    {
                        Ruta ruta = new Ruta(elemento.Content.ToString());
                        ruta.Leer();
                        rutasRealizadas.Add(ruta);
                    }
                }
                try
                {
                    int excursionistasModificados;
                    if ((excursionistasModificados = excursionista.Modificar()) != 1)
                    {
                        MessageBox.Show("Se han modificado " + excursionistasModificados +
                            " rutas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    excursionista.RutasRealizadas = rutasRealizadas;
                    excursionista.RutasPlaneadas = rutasPlaneadas;
                    excursionista.EliminarRutas();
                    excursionista.InsertarRutas();
                    BtnLimpiarExc_Click(sender, e);
                    LstBoxExc.Items.Clear();
                    RellenarLstBoxExc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private List<string> ObtenerNombresPromos()
        {
            PromocionRuta promo = new PromocionRuta();
            try
            {
                promo.LeerTodas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            List<string> nombresPromos = new List<string>();
            foreach (PromocionRuta p in promo.Dao.PromocionesRutas)
            {
                nombresPromos.Add(p.Nombre);
            }
            return nombresPromos;
        }

        private void RellenarLstBoxPromos()
        {
            foreach (string nombreRuta in ObtenerNombresPromos())
            {
                LstBoxPromo.Items.Add(nombreRuta);
            }
        }

        private void TxtBuscarPromo_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = TxtBuscarPromo.Text;
            LstBoxPromo.Items.Clear();

            if (string.IsNullOrEmpty(busqueda))
            {
                RellenarLstBoxPromos();
            }
            else
            {
                IEnumerable<string> promosFiltradas = ObtenerNombresPromos()
                    .Where(promo => promo.ToLower().Contains(busqueda.ToLower()));
                foreach (string promo in promosFiltradas)
                {
                    LstBoxPromo.Items.Add(promo);
                }
            }
        }

        private void LstBoxPromo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnAnadirPromo.IsEnabled = false;
            BtnModificarPromo.IsEnabled = true;
            BtnEliminarPromo.IsEnabled = true;

            if (LstBoxPromo.SelectedItem != null)
            {
                PromocionRuta promo = new PromocionRuta(LstBoxPromo.SelectedItem.ToString());
                try
                {
                    promo.Leer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                TxtNombrePromo.Text = promo.Nombre;
                TxtDescripcionPromo.Text = promo.Descripcion;
                ComboTipoPromo.SelectedValue = promo.Tipo;
            }
        }

        private void BtnLimpiarPromo_Click(object sender, RoutedEventArgs e)
        {
            LstBoxPromo.UnselectAll();
            TxtNombrePromo.Clear();
            ComboTipoPromo.SelectedItem = null;
            TxtDescripcionPromo.Clear();
            LstBoxAdjuntos.Items.Clear();
            BtnAnadirPromo.IsEnabled = true;
            BtnModificarPromo.IsEnabled = false;
            BtnEliminarPromo.IsEnabled = false;
        }

        private void BtnSalirDatosUsuario_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSalirRutas_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSalirGuias_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSalirExc_Clic(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSalirPromo_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
