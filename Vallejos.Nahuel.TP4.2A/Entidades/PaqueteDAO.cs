using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Constructor estatico que instancia los atributos del objeto PaqueteDAO
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();
        }
        /// <summary>
        /// Inserta un obj de tipo paquete a la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            comando.CommandText = string.Format("INSERT INTO Paquetes values ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID,"Vallejos Nahuel");
            //comando.CommandText = string.Format("INSERT INTO Paquetes values ('{1}')", p.DireccionEntrega);
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); 
                conexion.Close();

                return true;
                
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }






    }
}
