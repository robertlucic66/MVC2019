using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit.Models
{
    public class PokloniModel
    {
        public int IdPoklon { get; set; }
        public string NazivPoklona { get; set; }
        public double CijenaPoklona { get; set; }
        public bool KupljenPoklon { get; set; }

    }
}