using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3MVP
{
    public class Alergen
    {
        public int IdAlergen { get; set; }

        public string Denumire { get; set; }

        public string InfoAlergen
        {
            get { return $"{ Denumire }"; }
        }
    }
}
