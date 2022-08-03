using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using Npgsql;

namespace CapaDatos
{
    public class conexionBD
    {
        private static NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost; Database=LAB03; User Id=postgres; Password=sancarlos2015");
        public static void conectarPostgresSQL()
        {
            try
            {
                conexion.Open();
                Console.WriteLine("Conectado");
            }
            catch (Exception)
            {
                MessageBox.Show("Conexion Interrumpida...", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void desconectarPostgresSQL()
        {
            conexion.Close();
            Console.WriteLine("Desonectado");
        }

        public static DataTable consultaUnDato(string query)
        {
            try
            {
                conectarPostgresSQL();
                NpgsqlCommand conector = new NpgsqlCommand(query, conexion);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                desconectarPostgresSQL();
                return tabla;
            }
            catch
            {
                return null;
            }
        }

    }
}
