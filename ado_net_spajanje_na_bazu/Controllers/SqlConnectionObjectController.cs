using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ado_net_spajanje_na_bazu.Controllers
{
    public class SqlConnectionObjectController : Controller
    {
        // GET: SqlConnectionObject direktno
        public ActionResult Index()
        {
            // Prvo kreiramo conn string
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            // Nakon toga instanca Sqlconnection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if(conn.State == ConnectionState.Open)
                {
                    Response.Write("Konekcija je uspjela");
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write("Greška spajanja na bazu: " + sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("neka greška" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }


            return View();
        }

        // GET: SqlConnectionObject preko Web.config
        public ActionResult SpojPrekoWebConfig()
        {
            // Prvo kreiramo conn string
            //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            // Nakon toga instanca Sqlconnection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Response.Write("Konekcija je uspjela");
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write("Greška spajanja na bazu: " + sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("neka greška" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }


            return View();
        }
    }
}