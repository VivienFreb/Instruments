using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musique.Models
{
    public class Instrument
    {
        public int NumInstrument { get; set; }
        public DateTime DateAchat { get; set; }
        public double PrixAchat { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Couleur { get; set; }
        public string NumSerie { get; set; }
        public bool Utilisation { get; set; }
        public int idClasse { get; set; }
        public string CodeType { get; set; }
        public string Photo { get; set; }
    }
}