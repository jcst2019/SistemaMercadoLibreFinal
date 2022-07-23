using SistemaMercadoLibre.Pages.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public class GestionaRecepcion
    {
        public static SqlCommand cmd;


        public static List<Recepcion> RecepcionadosPorGenerarComprobante(SqlConnection conn, string idUsuario)
        {
            List<Recepcion> lstRecepcion = new List<Recepcion>();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spObtenerListaAsistenteRecepcionista";

                SqlParameter IdUsuario = cmd.Parameters.Add("@idUsuario", SqlDbType.Char);
                IdUsuario.Direction = ParameterDirection.Input;
                IdUsuario.Value = idUsuario;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recepcion recepcion = new Recepcion();
                        recepcion.IdRecepcion = reader["idRecepcion"].ToString();
                        recepcion.Observacion = reader["observacion"].ToString();
                        recepcion.FechaRegistro = DateTime.Parse(reader["fechaRegistro"].ToString());
                        recepcion.IdVenta = reader["idVenta"].ToString();
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

        public static Venta solicitarDatosVenta(SqlConnection conn, string idVenta)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spObternerDetalleVenta";
                cmd.Connection = conn;
                SqlParameter IdVenta = cmd.Parameters.Add("@idVenta", SqlDbType.Char);
                IdVenta.Direction = ParameterDirection.Input;
                IdVenta.Value = idVenta;

                SqlDataReader reader = cmd.ExecuteReader();
                Venta venta = new Venta();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        venta.IdVenta = reader["idVenta"].ToString();
                        venta.Importe = Double.Parse(reader["importe"].ToString());
                        //venta.FechaRegistro = DateTime.Parse(reader["fechaRegistro"].ToString());
                        //venta.Estado = Int32.Parse(reader["estado"].ToString());
                        //venta.NroOrden = reader["nroOrden"].ToString();
                        //venta.Subtotal = Double.Parse(reader["subtotal"].ToString());
                        //venta.Precio = Double.Parse(reader["importe"].ToString());
                        //venta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                        //venta.NombreProducto = reader["nombreProducto"].ToString();
                        //venta.NombreProveedor = reader["nombreProveedor"].ToString();

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

        public static string actualizarEstado(SqlConnection conn, Venta venta, string observacion, string idusuario)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spAceptarRechazarRecepcionista";
                cmd.Connection = conn;

                SqlParameter IdVenta = cmd.Parameters.Add("@idVenta", SqlDbType.Char);
                IdVenta.Direction = ParameterDirection.Input;
                IdVenta.Value = venta.IdVenta;

                SqlParameter Estado = cmd.Parameters.Add("@estado", SqlDbType.Int);
                Estado.Direction = ParameterDirection.Input;
                Estado.Value = venta.Estado;

                SqlParameter Observacion = cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 255);
                Observacion.Direction = ParameterDirection.Input;
                Observacion.Value = observacion;

                SqlParameter idUsuario = cmd.Parameters.Add("@idUsuario", SqlDbType.Char);
                idUsuario.Direction = ParameterDirection.Input;
                idUsuario.Value = idusuario;

                cmd.ExecuteNonQuery();

                return "Estado actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Ocurrió un error al actualizar estado " + ex.ToString();
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
                        venta.IdVenta = reader["idVenta"].ToString();
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

            String cadena = "spActualizarRecepcionista";

            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            try
            {

                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idRecepcion", recepcion.IdRecepcion));
                cmd.Parameters.Add(new SqlParameter("@estado", recepcion.Estado));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", recepcion.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@idVenta", recepcion.IdVenta));
                cmd.ExecuteNonQuery();

                return "Estado actualizado correctamente";

            }
            catch (SqlException err)
            {
                return "Ocurrió un error al actualizar estado " + err.ToString();

            }
        }
    }
}
