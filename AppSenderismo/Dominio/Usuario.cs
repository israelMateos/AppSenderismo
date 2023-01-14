using System;
using AppSenderismo.Persistencia;

namespace AppSenderismo.Dominio
{
    class Usuario
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public DateTime UltimoAcceso { get; set; }
        public readonly UsuarioDAO Dao;

        public Usuario()
        {
            Dao = new UsuarioDAO();
        }

        public Usuario(string email, string pass, string nombre,
            string apellidos, string telefono, string dni, DateTime ultimoAcceso)
        {
            Email = email;
            Pass = pass;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Dni = dni;
            UltimoAcceso = ultimoAcceso;
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
