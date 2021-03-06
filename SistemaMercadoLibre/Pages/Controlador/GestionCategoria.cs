using Microsoft.AspNetCore.Mvc;
using SistemaMercadoLibre.Pages.Modelo;
using System.Data.SqlClient;
using System.Data;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public static class GestionCategoria
    {
        public static List<Categoria> Listar()
        {
            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            List<Categoria> lista = new List<Categoria>();

            String cadena = "spCategoriasListarAll";
            try
            {
                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Categoria cat = new Categoria();
                    cat.setId(dr["idCategoria"].ToString());  //Comentario es la columna del la base de datos
                    cat.setDescripcion(dr["descripcion"].ToString());
                    cat.setEstado(dr["desEstado"].ToString());
                    cat.setFechaRegistro(dr["fechaRegistro"].ToString());

                    lista.Add(cat);
                }
                coon.Close();
                return lista;
            }
            /*
            try
            {
                using (SqlConnection oconexion = GestionDatos.conectar())
                {
                    string query = "select IdCategoria,Descripcion, Activo from categoria";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    if (oconexion.State != ConnectionState.Open && oconexion.State != ConnectionState.Connecting)
                    {
                        oconexion.Open();
                    }
                     List<Categoria> listCategoria = new List<Categoria>();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Categoria cat = new Categoria();
                            cat.setId((int)dr["IdCategoria"]);  //Comentario es la columna del la base de datos
                            cat.setDescripcion(dr["Descripcion"].ToString());
                            cat.setActivo(Convert.ToBoolean(dr["Activo"]));

                            lista.Add(cat);

                        }
                    }
                    oconexion.Close();

                }
            }*/
            catch
            {
                lista = new List<Categoria>();

            }
            return lista;
        }
        public static String InsertarCategoria(Categoria categoria)
        {
            String cadena = "spInsertCategoria";

            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            try
            {

                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@descripcion", categoria.getDescripcion()));
                cmd.Parameters.Add(new SqlParameter("@usuarioRegistro", categoria.getUsuarioRegistro()));
                cmd.Parameters.Add("@IdCadena", SqlDbType.Char, 5).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string ICategoria = cmd.Parameters["@idCadena"].Value.ToString();

                return ICategoria;

            }
            catch (SqlException err)
            {
                return "Error :" + err.Message;

            }
        }
        public static String ActualizarCategoria(Categoria categoria)
        {
            String cadena = "spUpadteCategoria";

            SqlConnection coon = GestionDatos.conectar();
            SqlCommand cmd;

            try
            {

                cmd = coon.CreateCommand();
                cmd.CommandText = cadena;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idCategoria", categoria.getId().ToString()));
                cmd.Parameters.Add(new SqlParameter("@descripcion", categoria.getDescripcion().ToString()));
                cmd.Parameters.Add(new SqlParameter("@estado", categoria.getEstado()));
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
