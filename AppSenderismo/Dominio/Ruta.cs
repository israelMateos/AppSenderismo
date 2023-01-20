using System;
using System.Collections.Generic;
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
        public Guia Guia { get; set; }
        public List<Excursionista> Excursionistas { get; set; }
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

        public Ruta(int id)
        {
            Id = id;
            Dao = new RutaDAO();
        }

        public Ruta(string nombre, string provincias, DateTime fecha,
            string origen, string destino, string dificultad, int duracionEstimada,
            string formaAcceso, string formaSalida, string materialNecesario,
            bool comidaEnRuta, Guia guia)
        {
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
            Guia = guia;
            Dao = new RutaDAO();
        }

        public Ruta(int id, string nombre, string provincias, DateTime fecha,
            string origen, string destino, string dificultad, int duracionEstimada,
            string formaAcceso, string formaSalida, string materialNecesario,
            bool comidaEnRuta, Guia guia)
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
            Guia = guia;
            Dao = new RutaDAO();
        }

        public void LeerTodas()
        {
            Dao.LeerTodas();
        }

        public void Leer()
        {
            Dao.Leer(this);
        }

        public void LeerPorId()
        {
            Dao.LeerPorId(this);
        }

        public void LeerExcursionistas()
        {
            Dao.LeerExcursionistas(this);
        }

        public int Insertar()
        {
            return Dao.Insertar(this);
        }

        public int Modificar()
        {
            return Dao.Modificar(this);
        }

        public int Eliminar()
        {
            return Dao.Eliminar(this);
        }
    }
}
