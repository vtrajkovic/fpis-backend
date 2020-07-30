using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using fpis.Klase;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlConnector;

namespace fpis.Controllers
{
    [ApiController]
    public class FPISController : ControllerBase
    {
        SqlConnection connection = new SqlConnection("Data Source=DESK-vtrajkovic;Initial Catalog=fpis;Integrated Security=True");

        DatabaseService ds = new DatabaseService();

        [HttpGet]
        [EnableCors("Policy")]
        [Route("api/fpis/Izvestaji")]
        public List<Izvestaj> getIzvestaji()
        {
            return ds.getIzvestaji();
        }

        [HttpDelete]
        [EnableCors("Policy")]
        [Route("api/fpis/deleteIzvestaji/{id}")]
        public bool deleteIzvestaj([FromRoute] int id)
        {
            
            return ds.deleteIzvestaj(id);
        }

        [HttpPost]
        [EnableCors("Policy")]
        [Route("api/fpis/updateIzvestaj")]
        public bool updateIzvestaj([FromBody] Izvestaj izvestaj)
        {
            var data = izvestaj;
            return ds.updateIzvestaj(izvestaj);
        }

        [HttpPost]
        [EnableCors("Policy")]
        [Route("api/fpis/createIzvestaj")]
        public bool createIzvestaj([FromBody] KlasaIzvestajZaUpis izvestaj)
        {
            return ds.createIzvestaj(izvestaj);
        }



        [HttpGet]
        [EnableCors("Policy")]
        [Route("api/fpis/getKlijentiFizicko")]
        public List<KlijentFizicko> getKlijentiFizicko()
        {
            return ds.getKlijentiFizicko();
        }


        [HttpGet]
        [EnableCors("Policy")]
        [Route("api/fpis/getKlijenti")]
        public List<Klijent> getKlijenti ()
        {
            return ds.getKlijenti();
        }

        [HttpDelete]
        [EnableCors("Policy")]
        [Route("api/fpis/deleteRacun/{brojRacuna}")]
        public bool deleteRacun([FromRoute] string brojRacuna)
        {

            return ds.deleteRacun(brojRacuna);
        }

        [HttpPost]
        [EnableCors("Policy")]
        [Route("api/fpis/updateRacun")]
        public bool updateRacun([FromBody] Racun r)
        {
            var data = r;
            return ds.updateRacun(r);
        }

        [HttpPost]
        [EnableCors("Policy")]
        [Route("api/fpis/createRacun")]
        public bool createRacun([FromBody] Racun r)
        {
            var data = r;
            return ds.createRacun(r);
        }

        [HttpPost]
        [EnableCors("Policy")]
        [Route("api/fpis/createKlijentFizicko")]
        public bool createKlijentFizicko([FromBody] KlijentFizicko k)
        {
            var data = k;
            return ds.createKlijentFizicko(k);
        }
        [HttpPost]
        [EnableCors("Policy")]
        [Route("api/fpis/updateKlijentFizicko")]
        public bool updateKlijentFizicko([FromBody] KlijentFizicko k)
        {
            var data = k;
            return ds.updateKlijentFizicko(k);
        }

        [HttpDelete]
        [EnableCors("Policy")]
        [Route("api/fpis/deleteKlijentFizicko/{id}")]
        public bool deleteKlijentFizicko([FromRoute] int id)
        {

            return ds.deleteKlijentFizicko(id);
        }

    }
}
