using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpis.Klase
{
    public class KlijentFizicko
    {
        int id;
        string jmbg;
        string imePrezime;
        string datumRodj;
        string drzavljanstvo;
        string brlk;
        string email;
        string adresa;
        List<Racun> listaRacuna;

        public KlijentFizicko()
        {
            listaRacuna = new List<Racun>();
        }

        public int Id { get => id; set => id = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string ImePrezime { get => imePrezime; set => imePrezime = value; }
        public string DatumRodj { get => datumRodj; set => datumRodj = value; }
        public string Drzavljanstvo { get => drzavljanstvo; set => drzavljanstvo = value; }
        public string Brlk { get => brlk; set => brlk = value; }
        public string Email { get => email; set => email = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public List<Racun> ListaRacuna { get => listaRacuna; set => listaRacuna = value; }
    }
}
