using System.Data;
using System.Data.SqlClient;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public class GestionaRecepcion
    {
        public static SqlCommand cmd;


        public static List<Recepcion> RecepcionadosPorGenerarComprobante(SqlConnection conn)
        {
            List<Recepcion> lstRecepcion = new List<Recepcion>();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spObtenerListaAsistenteRecepcionista";
                SqlDataReader reader = cmd.ExecuteReader();
               if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recepcion recepcion = new Recepcion();
                        recepcion.IdRecepcion = Int32.Parse(reader["idRecepcion"].ToString());
                        recepcion.Observacion = reader["observacion"].ToString();
                        recepcion.FechaRegistro = DateTime.Parse(reader["fechaRegistro"].ToString());
                        recepcion.IdVenta = Int32.Parse(reader["idVenta"].ToString());
                        recepcion.Estado = Int32.Parse(reader["estado"].ToString());
                        recepcion.NroOrden = reader["nroOrden"].ToString();
                        recepcion.NumComprobante = reader["numComprobante"].ToString();
                        lstRecepcion.Add(recepcion);
                    }
               }
                reader.Close();
                return lstRecepcion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static Venta solicitarDatosVenta(SqlConnection conn, int idVenta)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spObternerDetalleVenta";
                cmd.Connection = conn;
                SqlParameter IdVenta = cmd.Parameters.Add("@idVenta", SqlDbType.Int);
                IdVenta.Direction = ParameterDirection.Input;
                IdVenta.Value = idVenta;

                SqlDataReader reader = cmd.ExecuteReader();
                Venta venta = new Venta();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        venta.IdVenta = Int32.Parse(reader["idVenta"].ToString());
                        venta.Importe = Double.Parse(reader["importe"].ToString());
                        venta.FechaRegistro = DateTime.Parse(reader["fechaRegistro"].ToString());
                        venta.Estado = Int32.Parse(reader["estado"].ToString());
                    }
                }
                reader.Close();
                return venta;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string actualizarEstado(SqlConnection conn,Venta venta, string observacion,int idusuario)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spAceptarRechazarRecepcionista";
                cmd.Connection = conn;

                SqlParameter IdVenta = cmd.Parameters.Add("@idVenta", SqlDbType.Int);
                IdVenta.Direction = ParameterDirection.Input;
                IdVenta.Value = venta.IdVenta;

                SqlParameter Estado = cmd.Parameters.Add("@estado", SqlDbType.Int);
                Estado.Direction = ParameterDirection.Input;
                Estado.Value = venta.Estado;

                SqlParameter Observacion = cmd.Parameters.Add("@observacion", SqlDbType.VarChar,255);
                Observacion.Direction = ParameterDirection.Input;
                Observacion.Value = observacion;

                SqlParameter idUsuario = cmd.Parameters.Add("@idUsuario", SqlDbType.Int);
                idUsuario.Direction = ParameterDirection.Input;
                idUsuario.Value = idusuario;

                cmd.ExecuteNonQuery();
                
                return "Estado actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Ocurrió un error al actualizar estado "+ex.ToString();
            }
        }

        public static List<Venta> mostrarVentasEnTabla(SqlConnection conn)
        {
            List<Venta> lstVentas = new List<Venta>();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spObtenerListaVentasPorRecibir";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta venta = new Venta();
                        venta.IdVenta = Int32.Parse(reader["idVenta"].ToString());
                        venta.NroOrden = reader["nroOrden"].ToString();
                        venta.FechaRegistro = DateTime.Parse(reader["fechaRegistro"].ToString());
                        venta.Estado = Int32.Parse(reader["estado"].ToString());
                        lstVentas.Add(venta);
                    }
                }
                reader.Close();
                return lstVentas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public static string actualizarRecepcion(SqlConnection conn, Recepcion recepcion)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spActualizarRecepcionista";
                cmd.Connection = conn;

                SqlParameter IdRecepcion = cmd.Parameters.Add("@idRecepcion", SqlDbType.Int);
                IdRecepcion.Direction = ParameterDirection.Input;
                IdRecepcion.Value = recepcion.IdRecepcion;

                SqlParameter Estado = cmd.Parameters.Add("@estado", SqlDbType.Int);
                Estado.Direction = ParameterDirection.Input;
                Estado.Value = recepcion.Estado;

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