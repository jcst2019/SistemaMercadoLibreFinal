using Microsoft.AspNetCore.Mvc;
using SistemaMercadoLibre.Pages.Modelo;
using System.Data.SqlClient;
using System.Data;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public class GestionCedi
    {
        public static List<Cedi> Listar()
        {
            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            List<Cedi> lista = new List<Cedi>();

            String cadena = "spCedisListarAll";
            try
            {
                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cedi cedi = new Cedi();
                    cedi.setId(dr["idCedis"].ToString());  
                    cedi.setNombre(dr["nombre"].ToString()); 
                    cedi.setUbicacion(dr["ubicacion"].ToString());
                    cedi.setDireccion(dr["direccion"].ToString());
                    cedi.setCiudad(dr["ciudad"].ToString());

                    lista.Add(cedi);
                }
                coon.Close();
                return lista;
            }
            catch
            {
                lista = new List<Cedi>();

            }
            return lista;
        }

        public static String InsertarCedi(Cedi cedi)
        {
            String cadena = "spInsertCedis";

            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            try
            {

                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", cedi.getNombre()));
                cmd.Parameters.Add(new SqlParameter("@ubicacion", cedi.getUbicacion()));
                cmd.Parameters.Add(new SqlParameter("@direccion", cedi.getDireccion()));
                cmd.Parameters.Add(new SqlParameter("@ciudad", cedi.getCiudad()));
                cmd.Parameters.Add("@idCadena", SqlDbType.Char, 5).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string ICategoria = cmd.Parameters["@idCadena"].Value.ToString();

                return ICategoria;

            }
            catch (SqlException err)
            {
                return "Error :" + err.Message;

            }
        }

        public static String ActualizarCedi(Cedi cedi)
        {
            String cadena = "spUpadteCedi";

            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            try
            {
                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idCedis", cedi.getId().ToString()));
                cmd.Parameters.Add(new SqlParameter("@nombre", cedi.getNombre().ToString()));
                cmd.Parameters.Add(new SqlParameter("@ubicacion", cedi.getUbicacion().ToString()));
                cmd.Parameters.Add(new SqlParameter("@direccion", cedi.getDireccion().ToString()));
                cmd.Parameters.Add(new SqlParameter("@ciudad", cedi.getCiudad().ToString()));
                cmd.ExecuteNonQuery();

                return "Datos se modificaron exitosamente!";
            }
            catch (SqlException err)
            {
                return "Error :" + err.Message;

            }
        }
    }
}
