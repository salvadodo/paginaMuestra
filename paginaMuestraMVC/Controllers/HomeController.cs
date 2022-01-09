using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using paginaMuestraMVC.Models;

namespace paginaMuestraMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public String cargarRegistros()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ConnectionString))
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
                        res += "<div>" + dr.GetString(indtipodeCasa) + "</div>" + "<div>" + dr.GetString(indUbicacion) + "</div>"
                            + "<div>" + dr.GetString(indDescripcion) + "</div>" + "<div>" + dr.GetInt32(indDueño) + "</div>"
                            + "<div>" + dr.GetString(indNombre) + "</div>" + "<div>" + dr.GetInt32(indEdad) + "</div>"
                            + "<div>" + dr.GetString(indDireccion) + "</div><br>";
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}