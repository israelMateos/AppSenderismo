using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AppSenderismo.Persistencia
{
    public class Agente
    {
        private static Agente _instancia;
        private readonly MySqlConnection _conexion;

        private Agente()
        {
            MySqlConnectionStringBuilder constructor = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3306,
                UserID = "root",
                Password = "root",
                Database = "routes_management",
                SslMode = MySqlSslMode.None
            };
            _conexion = new MySqlConnection(constructor.ToString());
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

        public void Conectar()
        {
            if (_instancia._conexion.State == System.Data.ConnectionState.Closed)
            {
                _conexion.Open();
            }
        }

        public void Desconectar()
        {
            if (_instancia._conexion.State == System.Data.ConnectionState.Open)
            {
                _conexion.Close();
            }
        }

        public List<List<string>> Leer(string sql)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand(sql, _conexion);
            MySqlDataReader lector = comando.ExecuteReader();

            List<List<string>> resultado = new List<List<string>>();
            while (lector.Read())
            {
                List<string> fila = new List<string>();
                for (int i = 0; i < lector.FieldCount; i++)
                {
                    fila.Add(lector[i].ToString());
                }
                resultado.Add(fila);
            }

            Desconectar();
            return resultado;
        }

        public int Modificar(string sql)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand(sql, _conexion);
            int resultado = comando.ExecuteNonQuery();
            Desconectar();
            return resultado;
        }
    }
}
