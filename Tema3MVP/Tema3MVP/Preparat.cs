using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3MVP
{
    public class Preparat
    {
        public int IdPreparat { get; set; }

        public int IdCategorie { get; set; }

        public string Denumire { get; set; }

        public double Pret { get; set; }

        public int Cantitate { get; set; }

        public int CantitateTotala { get; set; }

        public string InfoPreparat
        {
            get { return $"{ Denumire }        { Pret } RON       { Cantitate } Grame"; }
        }
    }
}
