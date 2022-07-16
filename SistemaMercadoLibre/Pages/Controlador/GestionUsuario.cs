using SistemaMercadoLibre.Pages.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public class GestionUsuario
    {
        public static DtoValidaUsuario ValidarAccesoUsuario(Usuario usuario)
        {
            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            String cadena = "spValidaUsuario";
            DtoValidaUsuario dtoUsuario = new DtoValidaUsuario(); 

            try
            {

                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@correo", usuario.getCorreo()));
                cmd.Parameters.Add(new SqlParameter("@clave", usuario.getClave()));
                cmd.Parameters.Add("@Resultado", SqlDbType.Int, 5).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@idPersona", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@datos", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                dtoUsuario.setResultado((int)cmd.Parameters["@Resultado"].Value);
                dtoUsuario.setIdidPersona(cmd.Parameters["@idPersona"].Value.ToString());
                dtoUsuario.setIdUsuario(cmd.Parameters["@idUsuario"].Value.ToString());
                dtoUsuario.setDatos(cmd.Parameters["@datos"].Value.ToString());

                return dtoUsuario;

            }
            catch (SqlException err)
            {
                DtoValidaUsuario dtoUsuarioNull = new DtoValidaUsuario();
                dtoUsuarioNull.setResultado(-1);
                return dtoUsuarioNull;

            }
        }
    }
}
