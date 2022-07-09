using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public class GestionDatos
    {

        public static SqlConnection conn; //Por defecto se crean como Protected

        public static SqlConnection conectar()
        {
            try
            {
                String cadenaConexxion = "Data Source = LAPTOP-O8BUEG82; Initial Catalog = BdMercadoLibre; User ID = sa; Password = admin2021";
                conn = new SqlConnection(cadenaConexxion);
                conn.ConnectionString = cadenaConexxion;
                conn.Open();
                //lblMensaje.Text = "Conexión Exitosa";
                return conn;
            }
            catch (SqlException err)
            {
                //lblMensaje.Text = "No fue posible hacer la conexión" + err.Message;
                //return false;
                //return "No fue posible hacer la conexión" + err.Message;
                return null;
            }
        }
    }
}
