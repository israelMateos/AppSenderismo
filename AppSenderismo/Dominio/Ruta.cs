using System;
using AppSenderismo.Persistencia;

namespace AppSenderismo.Dominio
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Provincias { get; set; }
        public DateTime Fecha { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Dificultad { get; set; }
        public int DuracionEstimada { get; set; }
        public string FormaAcceso { get; set; }
        public string FormaSalida { get; set; }
        public string MaterialNecesario { get; set; }
        public bool ComidaEnRuta { get; set; }
        public readonly RutaDAO Dao;

        public Ruta()
        {
            Dao = new RutaDAO();
        }

        public Ruta(string nombre)
        {
            Nombre = nombre;
            Dao = new RutaDAO();
        }

        public Ruta(int id, string nombre, string provincias, DateTime fecha,
            string origen, string destino, string dificultad, int duracionEstimada,
            string formaAcceso, string formaSalida, string materialNecesario,
            bool comidaEnRuta)
        {
            Id = id;
            Nombre = nombre;
            Provincias = provincias;
            Fecha = fecha;
            Origen = origen;
            Destino = destino;
            Dificultad = dificultad;
            DuracionEstimada = duracionEstimada;
            FormaAcceso = formaAcceso;
            FormaSalida = formaSalida;
            MaterialNecesario = materialNecesario;
            ComidaEnRuta = comidaEnRuta;
            Dao = new RutaDAO();
        }
    }
}
