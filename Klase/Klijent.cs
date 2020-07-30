using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpis.Klase
{
    public class Klijent
    {
        int id;
        string naziv;
        string email;

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Email { get => email; set => email = value; }
    }
}
