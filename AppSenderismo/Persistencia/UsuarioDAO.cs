using System;
using System.Collections.Generic;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    public class UsuarioDAO
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
                Usuario usuario = new Usuario(usuarioLeido[0], usuarioLeido[1],
                    usuarioLeido[2], usuarioLeido[3], usuarioLeido[4],
                    usuarioLeido[5], DateTime.Parse(usuarioLeido[6]));
                usuarios.Add(usuario);
            }
        }

        public void Leer(Usuario usuario)
        {
            List<List<string>> usuariosLeidos =
                Agente.Instancia.Leer("SELECT * FROM `user` WHERE email = '" + usuario.Email + "'");
            foreach (List<string> usuarioLeido in usuariosLeidos)
            {
                usuario.Email = usuarioLeido[0];
                usuario.Pass = usuarioLeido[1];
                usuario.Nombre = usuarioLeido[2];
                usuario.Apellidos = usuarioLeido[3];
                usuario.Telefono = usuarioLeido[4];
                usuario.Dni = usuarioLeido[5];
                usuario.UltimoAcceso = DateTime.Parse(usuarioLeido[6]);
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
