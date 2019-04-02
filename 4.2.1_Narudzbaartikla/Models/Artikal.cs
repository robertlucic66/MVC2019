using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4._2._1_Narudzbaartikla.Models
{
    public class Artikal
    {
        public string Kategorija { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
    }
}