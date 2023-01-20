using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    public class PuntoDeInteresDAO
    {
        public readonly List<PuntoDeInteres> PuntosDeInteres;

        public PuntoDeInteresDAO()
        {
            PuntosDeInteres = new List<PuntoDeInteres>();
        }

        public void LeerTodos()
        {
            List<List<string>> puntosLeidos =
                Agente.Instancia.Leer("SELECT * FROM `interesting_site`");
            foreach (List<string> puntoLeido in puntosLeidos)
            {
                PuntoDeInteres punto = new PuntoDeInteres();
                if(!string.IsNullOrEmpty(puntoLeido[4]) && puntoLeido[4] != "NULL")
                {
                    Ruta ruta = new Ruta(int.Parse(puntoLeido[4]));
                    ruta.LeerPorId();
                    punto =
                        new PuntoDeInteres(int.Parse(puntoLeido[0]),
                        puntoLeido[1], puntoLeido[2],
                        puntoLeido[3], ruta);
                }
                else
                {
                    punto =
                        new PuntoDeInteres(int.Parse(puntoLeido[0]),
                        puntoLeido[1], puntoLeido[2],
                        puntoLeido[3]);
                }
                PuntosDeInteres.Add(punto);
            }
        }

        public void Leer(PuntoDeInteres punto)
        {
            List<List<string>> puntosLeidos =
                Agente.Instancia.Leer("SELECT * FROM `interesting_site` "
                + "WHERE phone = '" + punto.Nombre + "'");
            foreach (List<string> puntoLeido in puntosLeidos)
            {
                punto.Id = int.Parse(puntoLeido[0]);
                punto.Nombre = puntoLeido[1];
                punto.Tipologia = puntoLeido[2];
                punto.Descripcion = puntoLeido[3];
                Ruta ruta = new Ruta(int.Parse(puntoLeido[4]));
                ruta.LeerPorId();
                punto.Ruta = ruta;
            }
        }
    }
}
