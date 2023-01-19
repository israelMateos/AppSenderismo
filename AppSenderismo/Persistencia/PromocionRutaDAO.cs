using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSenderismo.Dominio;

namespace AppSenderismo.Persistencia
{
    public class PromocionRutaDAO
    {
        public readonly List<PromocionRuta> PromocionesRutas;

        public PromocionRutaDAO()
        {
            PromocionesRutas = new List<PromocionRuta>();
        }

        public void LeerTodas()
        {
            List<List<string>> promosLeidas =
                Agente.Instancia.Leer("SELECT * FROM `route_promotion`");
            foreach (List<string> promoLeida in promosLeidas)
            {
                PromocionRuta promo = new PromocionRuta(int.Parse(promoLeida[0]),
                    promoLeida[1], promoLeida[2], promoLeida[3]);
                PromocionesRutas.Add(promo);
            }
        }

        public void Leer(PromocionRuta promo)
        {
            List<List<string>> promosLeidas =
                Agente.Instancia.Leer("SELECT * FROM `route_promotion` WHERE name = '"
                + promo.Nombre + "'");
            foreach (List<string> promoLeida in promosLeidas)
            {
                promo.Id = int.Parse(promoLeida[0]);
                promo.Nombre = promoLeida[1];
                promo.Tipo = promoLeida[2];
                promo.Descripcion = promoLeida[3];
            }
        }

        public int Insertar(PromocionRuta promo)
        {
            return Agente.Instancia.Modificar("INSERT INTO `route_promotion` "
                + "(name, type, description) VALUES ('" + promo.Nombre + "', '"
                + promo.Tipo + "', '" + promo.Descripcion + "')");
        }

        public int Eliminar(PromocionRuta promo)
        {
            return Agente.Instancia.Modificar("DELETE FROM `route_promotion` WHERE "
                + "name='" + promo.Nombre + "'");
        }
    }
}
