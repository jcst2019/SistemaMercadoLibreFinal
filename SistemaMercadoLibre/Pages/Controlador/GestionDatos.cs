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
                String cadenaConexxion = "Data Source=DESKTOP-5335S7C\\SQLEXPRESS;Initial Catalog=db_mercado_libre;Integrated Security=True";
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
