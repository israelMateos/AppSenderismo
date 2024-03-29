﻿using System;
using System.Collections.Generic;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    public class RutaDAO
    {
        public readonly List<Ruta> Rutas;

        public RutaDAO()
        {
            Rutas = new List<Ruta>();
        }

        public void LeerTodas()
        {
            List<List<string>> rutasLeidas = Agente.Instancia.Leer("SELECT * FROM `route`");
            foreach (List<string> rutaLeida in rutasLeidas)
            {
                Guia guia = null;
                if (!(string.IsNullOrEmpty(rutaLeida[12]) || rutaLeida[12] == "NULL"))
                {
                    guia = new Guia(int.Parse(rutaLeida[12]));
                    guia.LeerPorId();
                }
                Ruta ruta = new Ruta(int.Parse(rutaLeida[0]), rutaLeida[1],
                    rutaLeida[2], DateTime.Parse(rutaLeida[3]),
                    rutaLeida[4], rutaLeida[5], rutaLeida[6],
                    int.Parse(rutaLeida[7]), rutaLeida[8], rutaLeida[9],
                    rutaLeida[10], bool.Parse(rutaLeida[11]), guia);
                Rutas.Add(ruta);
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
                Guia guia = null;
                if (!(string.IsNullOrEmpty(rutaLeida[12]) || rutaLeida[12] == "NULL"))
                {
                    guia = new Guia(int.Parse(rutaLeida[12]));
                    guia.LeerPorId();
                }
                ruta.Guia = guia;
            }
        }

        public void LeerPorId(Ruta ruta)
        {
            List<List<string>> rutasLeidas =
                Agente.Instancia.Leer("SELECT * FROM `route` WHERE id = '" + ruta.Id + "'");
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
                Guia guia = null;
                if (!(string.IsNullOrEmpty(rutaLeida[12]) || rutaLeida[12] == "NULL"))
                {
                    guia = new Guia(int.Parse(rutaLeida[12]));
                    guia.LeerPorId();
                }
                ruta.Guia = guia;
            }
        }

        public void LeerExcursionistas(Ruta ruta)
        {
            List<List<string>> excLeidos =
                Agente.Instancia.Leer("SELECT traveller.* FROM traveller JOIN takes "
                + "ON traveller.id = takes.traveller_id WHERE takes.route_id = "
                + ruta.Id);
            List<Excursionista> excursionistas = new List<Excursionista>();
            foreach (List<string> excLeido in excLeidos)
            {
                Excursionista excursionista =
                    new Excursionista(int.Parse(excLeido[0]), excLeido[1],
                    excLeido[2], excLeido[3], int.Parse(excLeido[4]));
                excursionistas.Add(excursionista);
            }
            ruta.Excursionistas = excursionistas;
        }

        public int Insertar(Ruta ruta)
        {
            if (ruta.Guia != null)
            {

            }
            Console.WriteLine("INSERT INTO route(name, provinces,"
                + " date_time, origin, destination, difficulty, estimated_duration,"
                + " access_way, exit_way, needed_material, eat_in_route, guide_id)"
                + " VALUES('" + ruta.Nombre + "', '" + ruta.Provincias + "', '"
                + ruta.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + ruta.Origen
                + "', '" + ruta.Destino + "', '" + ruta.Dificultad + "', '"
                + ruta.DuracionEstimada + "', '" + ruta.FormaAcceso + "', '"
                + ruta.FormaSalida + "', '" + ruta.MaterialNecesario + "', "
                + (ruta.ComidaEnRuta ? 1 : 0) + ", "
                + (ruta.Guia != null ? ruta.Guia.Id.ToString() : "NULL") + ")");
            return Agente.Instancia.Modificar("INSERT INTO route(name, provinces,"
                + " date_time, origin, destination, difficulty, estimated_duration,"
                + " access_way, exit_way, needed_material, eat_in_route, guide_id)"
                + " VALUES('" + ruta.Nombre + "', '" + ruta.Provincias + "', '"
                + ruta.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + ruta.Origen
                + "', '" + ruta.Destino + "', '" + ruta.Dificultad + "', '"
                + ruta.DuracionEstimada + "', '" + ruta.FormaAcceso + "', '"
                + ruta.FormaSalida + "', '" + ruta.MaterialNecesario + "', "
                + (ruta.ComidaEnRuta ? 1 : 0) + ", "
                + (ruta.Guia != null ? ruta.Guia.Id.ToString() : "NULL") + ")");
        }

        public int Modificar(Ruta ruta)
        {
            Console.WriteLine("UPDATE route SET provinces = '"
                + ruta.Provincias + "', date_time = '"
                + ruta.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', origin = '"
                + ruta.Origen + "', destination = '" + ruta.Destino + "', difficulty = '"
                + ruta.Dificultad + "', estimated_duration = '" + ruta.DuracionEstimada
                + "', access_way = '" + ruta.FormaAcceso + "', exit_way = '"
                + ruta.FormaSalida + "', needed_material = '" + ruta.MaterialNecesario
                + "', eat_in_route = " + (ruta.ComidaEnRuta ? 1 : 0) + ", guide_id = "
                + (ruta.Guia != null ? ruta.Guia.Id.ToString() : "NULL")
                + " WHERE name = '" + ruta.Nombre + "'");
            return Agente.Instancia.Modificar("UPDATE route SET provinces = '"
                + ruta.Provincias + "', date_time = '"
                + ruta.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', origin = '"
                + ruta.Origen + "', destination = '" + ruta.Destino + "', difficulty = '"
                + ruta.Dificultad + "', estimated_duration = '" + ruta.DuracionEstimada
                + "', access_way = '" + ruta.FormaAcceso + "', exit_way = '"
                + ruta.FormaSalida + "', needed_material = '" + ruta.MaterialNecesario
                + "', eat_in_route = " + (ruta.ComidaEnRuta ? 1 : 0) + ", guide_id = "
                + (ruta.Guia != null ? ruta.Guia.Id.ToString() : "NULL")
                + " WHERE name = '" + ruta.Nombre + "'");
        }

        public int Eliminar(Ruta ruta)
        {
            return Agente.Instancia.Modificar("DELETE FROM `route` WHERE name='"
                + ruta.Nombre + "'");
        }
    }
}
