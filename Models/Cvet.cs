using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Cvecara.Models
{
    public class Cvet
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Boja { get; set; }
        public decimal Cena { get; set; }

        public Cvet() { }

        public Cvet(DataRow cvet)
        {
            Id = (int)cvet["Id"];
            Naziv = cvet["Naziv"].ToString();
            Boja = cvet["Boja"].ToString();
            Cena = (decimal)cvet["Cena"];
        }
    }
}