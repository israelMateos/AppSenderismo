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
    }
}
