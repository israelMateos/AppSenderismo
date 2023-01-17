using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    public class GuiaDAO
    {
        public readonly List<Guia> guias;

        public GuiaDAO()
        {
            guias = new List<Guia>();
        }

        public void LeerTodos()
        {
            List<List<string>> guiasLeidos = Agente.Instancia.Leer("SELECT * FROM `guide`");
            foreach (List<string> guiaLeido in guiasLeidos)
            {
                Guia guia = new Guia(int.Parse(guiaLeido[0]), guiaLeido[1],
                    guiaLeido[2], guiaLeido[3], guiaLeido[4], guiaLeido[5],
                    guiaLeido[6], int.Parse(guiaLeido[7]));
                guias.Add(guia);
            }
        }

        public void Leer(Guia guia)
        {
            List<List<string>> guiasLeidos =
                Agente.Instancia.Leer("SELECT * FROM `guide` WHERE email = '"
                + guia.Email + "'");
            foreach (List<string> guiaLeido in guiasLeidos)
            {
                guia.Id = int.Parse(guiaLeido[0]);
                guia.Nombre = guiaLeido[1];
                guia.Apellidos = guiaLeido[2];
                guia.Telefono = guiaLeido[3];
                guia.Email = guiaLeido[4];
                guia.Idiomas = guiaLeido[5];
                guia.Restricciones = guiaLeido[6];
                guia.Puntuacion = int.Parse(guiaLeido[7]);
            }
        }

        public void LeerPorId(Guia guia)
        {
            List<List<string>> guiasLeidos =
                Agente.Instancia.Leer("SELECT * FROM `guide` WHERE id = '"
                + guia.Id + "'");
            foreach (List<string> guiaLeido in guiasLeidos)
            {
                guia.Id = int.Parse(guiaLeido[0]);
                guia.Nombre = guiaLeido[1];
                guia.Apellidos = guiaLeido[2];
                guia.Telefono = guiaLeido[3];
                guia.Email = guiaLeido[4];
                guia.Idiomas = guiaLeido[5];
                guia.Restricciones = guiaLeido[6];
                guia.Puntuacion = int.Parse(guiaLeido[7]);
            }
        }

        public List<Ruta> LeerRutas(Guia guia)
        {
            List<List<string>> rutasLeidas =
                Agente.Instancia.Leer("SELECT * FROM `route` WHERE guide_id = "
                + guia.Id);
            List<Ruta> rutasGuia = new List<Ruta>();
            foreach (List<string> rutaLeida in rutasLeidas)
            {
                Ruta ruta = new Ruta(int.Parse(rutaLeida[0]), rutaLeida[1],
                    rutaLeida[2], DateTime.Parse(rutaLeida[3]),
                    rutaLeida[4], rutaLeida[5], rutaLeida[6],
                    int.Parse(rutaLeida[7]), rutaLeida[8], rutaLeida[9],
                    rutaLeida[10], bool.Parse(rutaLeida[11]), guia);
                rutasGuia.Add(ruta);
            }
            return rutasGuia;
        }

        public int Insertar(Guia guia)
        {
            return Agente.Instancia.Modificar("INSERT INTO `guide` "
                + "(name, surname, phone, email, languages, "
                + "availability_restrictions, score) VALUES ('"
                + guia.Nombre + "', '" + guia.Apellidos + "', '"
                + guia.Telefono + "', '" + guia.Email + "', '"
                + guia.Idiomas + "', '" + guia.Restricciones + ", '"
                + guia.Puntuacion + "')");
        }

        public int Modificar(Guia guia)
        {
            return Agente.Instancia.Modificar("UPDATE `guide` SET name='" + guia.Nombre
                + "', apellidos='" + guia.Apellidos + "', phone='" + guia.Telefono
                + "', languages='" + guia.Idiomas + "', availability_restrictions='"
                + guia.Restricciones + "', score='" + guia.Puntuacion
                + "' WHERE email='" + guia.Email + "'");
        }

        public int Eliminar(Guia guia)
        {
            return Agente.Instancia.Modificar("DELETE FROM `guide` WHERE email='"
                + guia.Email + "'");
        }
    }
}
