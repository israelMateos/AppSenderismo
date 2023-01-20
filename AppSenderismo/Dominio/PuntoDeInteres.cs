using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Persistencia;

namespace AppSenderismo.Dominio
{
    public class PuntoDeInteres
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipologia { get; set; }
        public string Descripcion { get; set; }
        public Ruta Ruta { get; set; }
        public readonly PuntoDeInteresDAO Dao;

        public PuntoDeInteres()
        {
            Dao = new PuntoDeInteresDAO();
        }

        public PuntoDeInteres(string nombre)
        {
            Nombre = nombre;
            Dao = new PuntoDeInteresDAO();
        }

        public PuntoDeInteres(int id, string nombre, string tipologia,
            string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Tipologia = tipologia;
            Descripcion = descripcion;
            Dao = new PuntoDeInteresDAO();
        }

        public PuntoDeInteres(int id, string nombre, string tipologia,
            string descripcion, Ruta ruta)
        {
            Id = id;
            Nombre = nombre;
            Tipologia = tipologia;
            Descripcion = descripcion;
            Ruta = ruta;
            Dao = new PuntoDeInteresDAO();
        }

        public void LeerTodos()
        {
            Dao.LeerTodos();
        }

        public void Leer()
        {
            Dao.Leer(this);
        }
    }
}
