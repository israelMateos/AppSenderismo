using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Persistencia;

namespace AppSenderismo.Dominio
{
    public class Guia
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Idiomas { get; set; }
        public string Restricciones { get; set; }
        public int Puntuacion { get; set; }
        public readonly GuiaDAO Dao;

        public Guia()
        {
            Dao = new GuiaDAO();
        }

        public Guia(int id)
        {
            Id = id;
        }

        public Guia(string email)
        {
            Email = email;
        }

        public Guia(int id, string nombre, string apellidos, string telefono,
            string email, string idiomas, string restricciones, int puntuacion)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Email = email;
            Idiomas = idiomas;
            Restricciones = restricciones;
            Puntuacion = puntuacion;
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
