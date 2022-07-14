using SistemaMercadoLibre.Pages.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public class GestionGuiasPendientes
    {
        public static List<DtoGuiasPendientes> ListarGuiasPendientes(DtoGuiasPendientes dto)
        {
            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            List<DtoGuiasPendientes> lista = new List<DtoGuiasPendientes>();

            String cadena = "spListarGuiasPendientes";
            try
            {
                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@estado", dto.getEstadoProducto()));
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DtoGuiasPendientes guiaPendiente = new DtoGuiasPendientes();
                    guiaPendiente.setIdVenta(dr["idVenta"].ToString());  //Comentario es la columna del la base de datos
                    guiaPendiente.setIdCliente(dr["idCliente"].ToString());
                    guiaPendiente.setDatosCliente(dr["datosCliente"].ToString());
                    guiaPendiente.setIdProducto(dr["idProducto"].ToString());
                    guiaPendiente.setDescripcionProducto(dr["descripcionProducto"].ToString());
                    guiaPendiente.setFechaVenta(dr["fechaVenta"].ToString());
                    guiaPendiente.setFechaEstado(dr["fechaEstado"].ToString());
                    guiaPendiente.setDesEstadoProducto(dr["desEstadoProducto"].ToString());
                    guiaPendiente.setEstadoProducto((int)dr["estadoProducto"]);

                    lista.Add(guiaPendiente);
                }
                coon.Close();
                return lista;
            }
            catch
            {
                lista = new List<DtoGuiasPendientes>();

            }
            return lista;
        }
        public static String ActualizarEstadoProducto(DtoGuiasPendientes dto)
        {
            String cadena = "spUpadteEstadoProducto";

            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            try
            {

                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idProducto", dto.getIdProducto()));
                cmd.Parameters.Add(new SqlParameter("@estado", dto.getEstadoProducto()));
                cmd.ExecuteNonQuery();

                return "Producto se modificó exitosamente!";

            }
            catch (SqlException err)
            {
                return "Error :" + err.Message;

            }
        }
    }
}
