using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace paginaMuestra
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string cargarRegistros()
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["conBD"].ConnectionString))
            {
                string res = "";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_selectallDueñosInnerCasas";
                //cmd.CommandText = "sp_selectcolumnsDueñosInnerCasas";
                cmd.Connection = con; 
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                try
                {
                    while (dr.Read())
                    {
                        int indtipodeCasa = dr.GetOrdinal("tipodeCasa");
                        int indUbicacion = dr.GetOrdinal("Ubicacion");
                        int indDescripcion = dr.GetOrdinal("Descripcion");
                        int indDueño = dr.GetOrdinal("Dueño");
                        int indNombre = dr.GetOrdinal("Nombre"); 
                        int indEdad = dr.GetOrdinal("Edad");
                        int indDireccion = dr.GetOrdinal("Direccion");
                        res += "<div>" + dr.GetString(indtipodeCasa) + "</div>"+ "<div>" + dr.GetString(indUbicacion) + "</div>"
                            +"<div>" + dr.GetString(indDescripcion) + "</div>"+ "<div>" + dr.GetInt32(indDueño) + "</div>"
                            + "<div>" + dr.GetString(indNombre) + "</div>"+ "<div>" + dr.GetInt32(indEdad) + "</div>"
                            +"<div>" + dr.GetString(indDireccion) + "</div><br>";
                    }
                    return res;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    dr.Close();
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }

            }
        }
    }
}
