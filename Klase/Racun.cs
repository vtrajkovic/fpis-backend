using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpis.Klase
{
    public class Racun
    {
        string brojRacuna;
        string zaPlatu;
        string tip;
        int klijentId;

        public string BrojRacuna { get => brojRacuna; set => brojRacuna = value; }
        public string ZaPlatu { get => zaPlatu; set => zaPlatu = value; }
        public string Tip { get => tip; set => tip = value; }
        public int KlijentId { get => klijentId; set => klijentId = value; }
    }
}
