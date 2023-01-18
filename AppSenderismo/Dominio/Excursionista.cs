using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Persistencia;

namespace AppSenderismo.Dominio
{
    public class Excursionista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public List<Ruta> RutasPlaneadas { get; set; }
        public List<Ruta> RutasRealizadas { get; set; }
        public readonly ExcursionistaDAO Dao;

        public Excursionista()
        {
            RutasPlaneadas = new List<Ruta>();
            RutasRealizadas = new List<Ruta>();
            Dao = new ExcursionistaDAO();
        }

        public Excursionista(int id)
        {
            Id = id;
            RutasPlaneadas = new List<Ruta>();
            RutasRealizadas = new List<Ruta>();
            Dao = new ExcursionistaDAO();
        }

        public Excursionista(string telefono)
        {
            Telefono = telefono;
            RutasPlaneadas = new List<Ruta>();
            RutasRealizadas = new List<Ruta>();
            Dao = new ExcursionistaDAO();
        }

        public Excursionista(string nombre, string apellidos, string telefono,
            int edad)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Telefono = telefono;
            RutasPlaneadas = new List<Ruta>();
            RutasRealizadas = new List<Ruta>();
            Dao = new ExcursionistaDAO();
        }

        public Excursionista(int id, string nombre, string apellidos,
            string telefono, int edad)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Telefono = telefono;
            RutasPlaneadas = new List<Ruta>();
            RutasRealizadas = new List<Ruta>();
            Dao = new ExcursionistaDAO();
        }

        public void LeerTodos()
        {
            Dao.LeerTodos();
        }

        public void Leer()
        {
            Dao.Leer(this);
        }

        public int Insertar()
        {
            return Dao.Insertar(this);
        }

        public int InsertarRutas()
        {
            return Dao.InsertarRutas(this);
        }

        public int Eliminar()
        {
            return Dao.Eliminar(this);
        }

        public int EliminarRutas()
        {
            return Dao.EliminarRutas(this);
        }
    }
}
