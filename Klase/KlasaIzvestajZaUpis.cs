using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpis.Klase
{
    public class KlasaIzvestajZaUpis
    {
        string datum;
        string nalogid;
        int klijentid;

        public string Datum { get => datum; set => datum = value; }
        public string Nalogid { get => nalogid; set => nalogid = value; }
        public int Klijentid { get => klijentid; set => klijentid = value; }
    }
}
