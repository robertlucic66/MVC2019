using Ispit.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ispit.Controllers
{
    public class IspitController : Controller
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["dbPopisPoklona"].ConnectionString;

        public ActionResult prvi()
        {
            string datum = "Danas je " + DateTime.Now.ToLongDateString() + " , trenutno je " + DateTime.Now.ToString("h:mm:ss tt");
            return View((object)datum);
        }

        public ActionResult ListaPoklona()
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM tblPopisPoklona";
            SqlDataReader dr = null;
            List<PokloniModel> lstPokloni = new List<PokloniModel>();
            try
            {
                conn.Open();
                dr = cm.ExecuteReader();
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PokloniModel pokloni = new PokloniModel();
                            pokloni.IdPoklon = int.Parse(dr["IdPoklon"].ToString());
                            pokloni.NazivPoklona = dr["NazivPoklona"].ToString();
                            pokloni.CijenaPoklona = double.Parse(dr["CijenaPoklona"].ToString());
                            pokloni.KupljenPoklon = bool.Parse(dr["KupljenPoklon"].ToString());
                            lstPokloni.Add(pokloni);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja liste poklona. Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();                   
                }
                conn.Dispose();
                cm.Dispose();
            }
            return View(lstPokloni);
        }

        [HttpGet]
        public ActionResult DodajPoklon()
        {
            return View(new PokloniModel());
        }

        [HttpPost]
        public ActionResult DodajPoklon(PokloniModel model)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbPopisPoklona"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string cmdText = "";
                    cmdText += "INSERT INTO tblPopisPoklona ";
                    cmdText += "(NazivPoklona, CijenaPoklona, KupljenPoklon) ";
                    cmdText += "VALUES ";
                    cmdText += "('" + model.NazivPoklona + "', '"
                        + model.CijenaPoklona + "', '" + model.KupljenPoklon + "') ";

                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    int brojDodanihPoklona = cmd.ExecuteNonQuery();
                    ViewBag.Message = "Broj dodanih poklona: " + brojDodanihPoklona;
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dodavanja poklona. Opis: " + ex.Message;
            }
            return View(model);         
        }

        [HttpGet]
        public ActionResult Uredi(int IdPoklon)
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdText = "SELECT * FROM tblPopisPoklona WHERE IdPoklon=@IdPoklon";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdPoklon";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Input;
            param.Value = IdPoklon;
            cmd.Parameters.Add(param);
            SqlDataReader dr = null;
            PokloniModel pokloni = new PokloniModel();
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //pokloni.IdPoklon = int.Parse(dr["IdPoklon"].ToString());
                            //pokloni.NazivPoklona = dr["NazivPoklona"].ToString();
                            //pokloni.CijenaPoklona = double.Parse(dr["CijenaPoklona"].ToString());
                            pokloni.KupljenPoklon = bool.Parse(dr["KupljenPoklon"].ToString());
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja poklona. Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(pokloni);
        }

        [HttpPost]
        public ActionResult Uredi(PokloniModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string cmdText = "";
                    cmdText += "UPDATE tblPopisPoklona ";
                    cmdText += "SET KupljenPoklon = '" + model.KupljenPoklon;
                    cmdText += "' WHERE IdPoklon = '" + model.IdPoklon + "'";
                    

                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    int brojDodanihPoklona = cmd.ExecuteNonQuery();
                    if(brojDodanihPoklona > 0)
                    {
                        ViewBag.Message = "Zapis je upisan u bazi";
                    }
                    else
                    {
                        ViewBag.Message = "Dogodila se greška!";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dodavanja poklona. Opis: " + ex.Message;
            }
            return View(model);
        }

    }
}