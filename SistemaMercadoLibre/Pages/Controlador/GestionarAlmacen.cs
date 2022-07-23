using SistemaMercadoLibre.Pages.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public class GestionarAlmacen
    {
        public static SqlCommand cmd;
        public static List<Audicion> obtenerListPorAlmacenar(SqlConnection conn)
        {
            List<Audicion> auditorList = new List<Audicion>();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spObtenerListaPorAlmacenar";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Audicion audicion = new Audicion();
                        audicion.IdAuditoria = reader["idAuditoria"].ToString();
                        audicion.IdRecepcion = reader["idRecepcion"].ToString();
                        audicion.IdVenta = reader["idVenta"].ToString();
                        audicion.Fechaventa = DateTime.Parse(reader["fechaventa"].ToString());
                        audicion.FechamodificacionAudicion = DateTime.Parse(reader["fechamodificacionAudicion"].ToString());
                        audicion.FechamodificacionRecepcion = DateTime.Parse(reader["fechamodificacionRecepcion"].ToString());
                        audicion.Observacion = reader["observacion"].ToString();
                        audicion.NroOrden = reader["nroOrden"].ToString();
                        audicion.EstadoRecepcion = Int32.Parse(reader["estadoRecepcion"].ToString());
                        audicion.Estado = Int32.Parse(reader["estado"].ToString());

                        auditorList.Add(audicion);
                    }
                }
                reader.Close();
                return auditorList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string aceptarIngresoAlmacen(SqlConnection conn, Audicion audicion)
        {
            List<Audicion> auditorList = new List<Audicion>();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spAceptarIngresoAlmacen";

                SqlParameter IdAudicion = cmd.Parameters.Add("@idAuditoria", SqlDbType.Char);
                IdAudicion.Direction = ParameterDirection.Input;
                IdAudicion.Value = audicion.IdAuditoria;

                SqlParameter Estado = cmd.Parameters.Add("@estado", SqlDbType.Int);
                Estado.Direction = ParameterDirection.Input;
                Estado.Value = audicion.Estado;

                SqlParameter IdVenta = cmd.Parameters.Add("@idVenta", SqlDbType.Char);
                IdVenta.Direction = ParameterDirection.Input;
                IdVenta.Value = audicion.IdVenta;

                cmd.ExecuteNonQuery();

                return "Estado actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Ocurrió un error al actualizar estado " + ex.ToString();
            }
        }

    }
}
