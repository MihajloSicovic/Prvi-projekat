using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cvecara.Models;
using Cvecara.Konekcija;
using System.Security.Principal;
using System.Net.Http;
using System.Web.UI;

namespace Cvecara.Controllers
{
    public class CvetController : Controller
    {
        // GET: Cvet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unesi()
        {
            return View();
        }

        public ActionResult SacuvajPodatke(Cvet cvet)
        {
            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Konektuj()))
            {
                using (SqlCommand kom = new SqlCommand("INSERT INTO cvet VALUES ('" + cvet.Naziv + "', '" + cvet.Boja + "', " + cvet.Cena + ")", kon))
                {
                    if (kon.State != ConnectionState.Open) kon.Open();
                    kom.ExecuteNonQuery();
                }
            }

            return RedirectToAction("TabelaCveca");
        }

        public ActionResult TabelaCveca()
        {
            List<Cvet> cvece = new List<Cvet>();
            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Konektuj()))
            {
                using (SqlCommand kom = new SqlCommand("SELECT * FROM cvet", kon))
                {
                    if (kon.State != ConnectionState.Open) kon.Open();

                    SqlDataReader drCvet = kom.ExecuteReader();
                    DataTable dtCvet = new DataTable();
                    dtCvet.Load(drCvet);

                    foreach (DataRow CvetSlog in dtCvet.Rows) cvece.Add(new Cvet(CvetSlog));
                }
            }

            return View(cvece);
        }
    }
}