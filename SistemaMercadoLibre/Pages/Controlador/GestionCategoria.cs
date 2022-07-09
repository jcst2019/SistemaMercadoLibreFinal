﻿using Microsoft.AspNetCore.Mvc;
using SistemaMercadoLibre.Pages.Modelo;
using System.Data.SqlClient;
using System.Data;

namespace SistemaMercadoLibre.Pages.Controlador
{
    public static class GestionCategoria
    {
        public static List<Categoria> Listar()
        {

            List<Categoria> lista = new List<Categoria>();
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
            }
            catch
            {
                lista = new List<Categoria>();
              
            }
            return lista;
        }
        public static String MostrarEstadoActivo(bool estado) {
            String cadena;

            if (estado)
            {
                cadena = "<span class='badge bg-success'>Activo</span>";
            }
            else
            {
                cadena = "<span class='badge bg-danger'>De Baja</span>";
            }
            return cadena;
            
        }
    }
}
