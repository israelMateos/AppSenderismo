using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    public class ExcursionistaDAO
    {
        public readonly List<Excursionista> excursionistas;

        public ExcursionistaDAO()
        {
            excursionistas = new List<Excursionista>();
        }

        public void LeerTodos()
        {
            List<List<string>> excursionistasLeidos =
                Agente.Instancia.Leer("SELECT * FROM `traveller`");
            foreach (List<string> excursionistaLeido in excursionistasLeidos)
            {
                Excursionista excursionista =
                    new Excursionista(int.Parse(excursionistaLeido[0]),
                    excursionistaLeido[1], excursionistaLeido[2],
                    excursionistaLeido[3], int.Parse(excursionistaLeido[4]));
                excursionistas.Add(excursionista);
            }
        }

        public void Leer(Excursionista excursionista)
        {
            List<List<string>> excursionistasLeidos =
                Agente.Instancia.Leer("SELECT * FROM `traveller` WHERE phone = '"
                + excursionista.Telefono + "'");
            foreach (List<string> excursionistaLeido in excursionistasLeidos)
            {
                excursionista.Id = int.Parse(excursionistaLeido[0]);
                excursionista.Nombre = excursionistaLeido[1];
                excursionista.Apellidos = excursionistaLeido[2];
                excursionista.Telefono = excursionistaLeido[3];
                excursionista.Edad = int.Parse(excursionistaLeido[4]);
                LeerRutasPlaneadas(excursionista);
                LeerRutasRealizadas(excursionista);
            }
        }

        public void LeerPorId(Excursionista excursionista)
        {
            List<List<string>> excursionistasLeidos =
                Agente.Instancia.Leer("SELECT * FROM `traveller` WHERE id = '"
                + excursionista.Id + "'");
            foreach (List<string> excursionistaLeido in excursionistasLeidos)
            {
                excursionista.Id = int.Parse(excursionistaLeido[0]);
                excursionista.Nombre = excursionistaLeido[1];
                excursionista.Apellidos = excursionistaLeido[2];
                excursionista.Telefono = excursionistaLeido[3];
                excursionista.Edad = int.Parse(excursionistaLeido[4]);
                LeerRutasPlaneadas(excursionista);
                LeerRutasRealizadas(excursionista);
            }
        }

        private void LeerRutasPlaneadas(Excursionista excursionista)
        {
            List<List<string>> rutasLeidas =
                Agente.Instancia.Leer("SELECT route.* FROM route JOIN takes "
                + "ON route.id = takes.route_id WHERE takes.traveller_id = "
                + excursionista.Id + " AND route.date_time > CURRENT_DATE();");
            List<Ruta> rutasPlaneadas = new List<Ruta>();
            foreach (List<string> rutaLeida in rutasLeidas)
            {
                Ruta ruta = new Ruta(int.Parse(rutaLeida[0]), rutaLeida[1],
                    rutaLeida[2], DateTime.Parse(rutaLeida[3]),
                    rutaLeida[4], rutaLeida[5], rutaLeida[6],
                    int.Parse(rutaLeida[7]), rutaLeida[8], rutaLeida[9],
                    rutaLeida[10], bool.Parse(rutaLeida[11]),
                    new Guia(int.Parse(rutaLeida[12])));
                rutasPlaneadas.Add(ruta);
            }
            excursionista.RutasPlaneadas = rutasPlaneadas;
        }

        private void LeerRutasRealizadas(Excursionista excursionista)
        {
            List<List<string>> rutasLeidas =
                Agente.Instancia.Leer("SELECT route.* FROM route JOIN takes "
                + "ON route.id = takes.route_id WHERE takes.traveller_id = "
                + excursionista.Id + " AND route.date_time <= CURRENT_DATE();");
            List<Ruta> rutasRealizadas = new List<Ruta>();
            foreach (List<string> rutaLeida in rutasLeidas)
            {
                Ruta ruta = new Ruta(int.Parse(rutaLeida[0]), rutaLeida[1],
                    rutaLeida[2], DateTime.Parse(rutaLeida[3]),
                    rutaLeida[4], rutaLeida[5], rutaLeida[6],
                    int.Parse(rutaLeida[7]), rutaLeida[8], rutaLeida[9],
                    rutaLeida[10], bool.Parse(rutaLeida[11]),
                    new Guia(int.Parse(rutaLeida[12])));
                rutasRealizadas.Add(ruta);
            }
            excursionista.RutasRealizadas = rutasRealizadas;
        }
    }
}
