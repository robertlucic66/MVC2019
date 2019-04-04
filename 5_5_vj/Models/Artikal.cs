using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5_5_vj.Models
{
    public class Artikal
    {
        public Artikal()
        {
        }

        public Artikal(string naziv, decimal cijena, string kategorija)
        {
            Kategorija = kategorija;
            Naziv = naziv;
            Cijena = cijena;
        }

        public string Kategorija { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
    }


}