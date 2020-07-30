using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpis.Klase
{
    public enum Status { NijeMenjano, Izmenjen, Obrisan, Dodat}
    public class Izvestaj
    {
        int id;
        string datum;
        int nalogid;
        string klijent;
        int klijentId;
        Status status;

        public int Id { get => id; set => id = value; }
        public string Datum { get => datum; set => datum = value; }
        public int Nalogid { get => nalogid; set => nalogid = value; }
        public string Klijent{ get => klijent; set => klijent = value; }
        public Status Status { get => status; set => status = value; }
        public int KlijentId { get => klijentId; set => klijentId = value; }
    }

}
