using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AppSenderismo.Persistencia
{
    class Agente
    {
        private static Agente _instancia;
        private readonly MySqlConnection _conexion;

        private Agente()
        {
            string cadenaConexion = $"Server=localhost;Port=3306;Database=rutas;Uid=root;Pwd=root;";
            _conexion = new MySqlConnection(cadenaConexion);
        }

        public static Agente Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Agente();
                }
                return _instancia;
            }
        }

        public List<List<string>> Leer(string sql)
        {
            _conexion.Open();
            MySqlCommand comando = new MySqlCommand(sql, _conexion);
            MySqlDataReader lector = comando.ExecuteReader();

            List<List<string>> resultado = new List<List<string>>();
            while (lector.Read())
            {
                List<string> fila = new List<string>();
                for (int i = 0; i < lector.FieldCount - 1; i++)
                {
                    fila.Add(lector[i].ToString());
                }
                resultado.Add(fila);
            }

            _conexion.Close();
            return resultado;
        }

        public int Modificar(string sql)
        {
            _conexion.Open();
            MySqlCommand comando = new MySqlCommand(sql, _conexion);
            int resultado = comando.ExecuteNonQuery();
            _conexion.Close();
            return resultado;
        }
    }
}
