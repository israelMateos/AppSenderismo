using System;
using System.Collections.Generic;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    class UsuarioDAO
    {
        public readonly List<Usuario> usuarios;

        public UsuarioDAO()
        {
            usuarios = new List<Usuario>();
        }

        public void LeerTodos()
        {
            List<List<string>> usuariosLeidos = Agente.Instancia.Leer("SELECT * FROM `user`");
            foreach (List<string> usuarioLeido in usuariosLeidos)
            {
                Usuario usuario = new Usuario(usuarioLeido[0].ToString(),
                    usuarioLeido[1].ToString(), usuarioLeido[2].ToString(),
                    usuarioLeido[3].ToString(), usuarioLeido[4].ToString(),
                    usuarioLeido[5].ToString(), DateTime.Parse(usuarioLeido[6]));
                usuarios.Add(usuario);
            }
        }

        public void Leer(Usuario usuario)
        {
            List<List<string>> usuariosLeidos =
                Agente.Instancia.Leer("SELECT * FROM `user` WHERE email = " + usuario.Email);
            foreach (List<string> usuarioLeido in usuariosLeidos)
            {
                usuario.Email = usuarioLeido[0].ToString();
                usuario.Pass = usuarioLeido[1].ToString();
                usuario.Nombre = usuarioLeido[2].ToString();
                usuario.Apellidos = usuarioLeido[3].ToString();
                usuario.Telefono = usuarioLeido[4].ToString();
                usuario.Dni = usuarioLeido[5].ToString();
                usuario.UltimoAcceso = DateTime.Parse(usuarioLeido[7]);
            }
        }

        public int Insertar(Usuario usuario)
        {
            return Agente.Instancia.Modificar("INSERT INTO `user` "
                + "(email, password, name, surname, phone, dni) VALUES ('"
                + usuario.Email + "', '" + usuario.Pass + "', '"
                + usuario.Nombre + "', '" + usuario.Apellidos + "', '"
                + usuario.Telefono + "', '" + usuario.Dni + "')");
        }

        public int Modificar(Usuario usuario)
        {
            return Agente.Instancia.Modificar("UPDATE `user` SET password='" + usuario.Pass
                + "', name='" + usuario.Nombre + "', surname='" + usuario.Apellidos
                + "', phone='" + usuario.Telefono + "', dni='" + usuario.Dni
                + "' WHERE email='" + usuario.Email + "'");
        }

        public int Eliminar(Usuario usuario)
        {
            return Agente.Instancia.Modificar("DELETE FROM `user` WHERE email='"
                + usuario.Email + "'");
        }
    }
}
