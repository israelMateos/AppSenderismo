using System;
using System.Collections.Generic;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    public class RutaDAO
    {
        public readonly List<Ruta> rutas;

        public RutaDAO()
        {
            rutas = new List<Ruta>();
        }

        public void LeerTodas()
        {
            List<List<string>> rutasLeidas = Agente.Instancia.Leer("SELECT * FROM `route`");
            foreach (List<string> rutaLeida in rutasLeidas)
            {
                Ruta ruta = new Ruta(int.Parse(rutaLeida[0]),
                    rutaLeida[1], rutaLeida[2], DateTime.Parse(rutaLeida[3]),
                    rutaLeida[4], rutaLeida[5], rutaLeida[6],
                    int.Parse(rutaLeida[7]), rutaLeida[8], rutaLeida[9],
                    rutaLeida[10], bool.Parse(rutaLeida[11]));
                rutas.Add(ruta);
            }
        }

        public void Leer(Ruta ruta)
        {
            List<List<string>> rutasLeidas =
                Agente.Instancia.Leer("SELECT * FROM `route` WHERE name = '" + ruta.Nombre + "'");
            foreach (List<string> rutaLeida in rutasLeidas)
            {
                ruta.Id = int.Parse(rutaLeida[0]);
                ruta.Nombre = rutaLeida[1];
                ruta.Provincias = rutaLeida[2];
                ruta.Fecha = DateTime.Parse(rutaLeida[3]);
                ruta.Origen = rutaLeida[4];
                ruta.Destino = rutaLeida[5];
                ruta.Dificultad = rutaLeida[6];
                ruta.DuracionEstimada = int.Parse(rutaLeida[7]);
                ruta.FormaAcceso = rutaLeida[8];
                ruta.FormaSalida = rutaLeida[9];
                ruta.MaterialNecesario = rutaLeida[10];
                ruta.ComidaEnRuta = bool.Parse(rutaLeida[11]);
            }
        }

        public int Insertar(Ruta ruta)
        {
            return Agente.Instancia.Modificar("INSERT INTO route(name, provinces,"
                + " date_time, origin, destination, difficulty, estimated_duration,"
                + " access_way, exit_way, needed_material, eat_in_route) VALUES('"
                + ruta.Nombre + "', '" + ruta.Provincias + "', '"
                + ruta.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + ruta.Origen
                + "', '" + ruta.Destino + "', '" + ruta.Dificultad + "', '"
                + ruta.DuracionEstimada + "', '" + ruta.FormaAcceso + "', '"
                + ruta.FormaSalida + "', '" + ruta.MaterialNecesario + "', '"
                + (ruta.ComidaEnRuta ? 1 : 0) + "')");
        }

        public int Modificar(Ruta ruta)
        {
            return Agente.Instancia.Modificar("UPDATE route SET name = "
                + ruta.Nombre + ", provinces = " + ruta.Provincias + ", date_time = "
                + ruta.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + ", origin = "
                + ruta.Origen + ", destination = " + ruta.Destino + ", difficulty = "
                + ruta.Dificultad + ", estimated_duration = " + ruta.DuracionEstimada
                + ", access_way = " + ruta.FormaAcceso + ", exit_way = "
                + ruta.FormaSalida + ", needed_material = " + ruta.MaterialNecesario
                + ", eat_in_route = " + (ruta.ComidaEnRuta ? 1 : 0)
                + " WHERE name = " + ruta.Nombre);
        }

        public int Eliminar(Ruta ruta)
        {
            return Agente.Instancia.Modificar("DELETE FROM `route` WHERE name='"
                + ruta.Nombre + "'");
        }
    }
}
