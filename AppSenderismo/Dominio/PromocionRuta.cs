using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Persistencia;

namespace AppSenderismo.Dominio
{
    public class PromocionRuta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public readonly PromocionRutaDAO Dao;

        public PromocionRuta()
        {
            Dao = new PromocionRutaDAO();
        }

        public PromocionRuta(string nombre)
        {
            Nombre = nombre;
            Dao = new PromocionRutaDAO();
        }

        public PromocionRuta(string nombre, string tipo, string descripcion)
        {
            Nombre = nombre;
            Tipo = tipo;
            Descripcion = descripcion;
            Dao = new PromocionRutaDAO();
        }

        public PromocionRuta(int id, string nombre, string tipo, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Tipo = tipo;
            Descripcion = descripcion;
            Dao = new PromocionRutaDAO();
        }

        public void LeerTodas()
        {
            Dao.LeerTodas();
        }

        public void Leer()
        {
            Dao.Leer(this);
        }

        public int Eliminar()
        {
            return Dao.Eliminar(this);
        }
    }
}
